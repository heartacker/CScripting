using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;


namespace Python
{
    public static class ClassHelper
    {
        internal static bool ShouldBindMethod(MethodBase mb)
        {
            return (mb.IsPublic || mb.IsFamily || mb.IsFamilyOrAssembly);
        }

        internal static bool ShouldBindField(FieldInfo fi)
        {
            return (fi.IsPublic || fi.IsFamily || fi.IsFamilyOrAssembly);
        }

        internal static bool ShouldBindProperty(PropertyInfo pi)
        {
            MethodInfo mm;
            try
            {
                mm = pi.GetGetMethod(true);
                if (mm == null)
                {
                    mm = pi.GetSetMethod(true);
                }
            }
            catch (SecurityException)
            {
                // GetGetMethod may try to get a method protected by
                // StrongNameIdentityPermission - effectively private.
                return false;
            }

            if (mm == null)
            {
                return false;
            }

            return ShouldBindMethod(mm);
        }

        internal static bool ShouldBindEvent(EventInfo ei)
        {
            return ShouldBindMethod(ei.GetAddMethod(true));
        }




        // Binding flags to determine which members to expose in Python.
        // This is complicated because inheritance in Python is name
        // based. We can't just find DeclaredOnly members, because we
        // could have a base class A that defines two overloads of a
        // method and a class B that defines two more. The name-based
        // descriptor Python will find needs to know about inherited
        // overloads as well as those declared on the sub class.
        internal static readonly BindingFlags BindingFlags = BindingFlags.Static |
                                                             BindingFlags.Instance |
                                                             BindingFlags.Public |
                                                             BindingFlags.NonPublic;


        /// <summary>
        /// This class owns references to PyObjects in the `members` member.
        /// The caller has responsibility to DECREF them.
        /// </summary>
        internal class ClassInfo
        {
            //public Indexer? indexer;
            public readonly Dictionary<string, Object> members = new Dictionary<string, object>();

            internal ClassInfo()
            {
                //indexer = null;
            }
        }


        internal static ClassInfo GetClassInfo(Type type, ClassBase impl = null)
        {
            var ci = new ClassInfo();
            var methods = new Dictionary<string, List<MethodBase>>();
            MethodInfo meth;
            ExtensionType ob;
            string name;
            Type tp;
            int i, n;

            MemberInfo[] info = type.GetMembers(BindingFlags);
            var local = new HashSet<string>();
            var items = new List<MemberInfo>();
            MemberInfo m;

            // Loop through once to find out which names are declared
            for (i = 0; i < info.Length; i++)
            {
                m = info[i];
                if (m.DeclaringType == type)
                {
                    local.Add(m.Name);
                }
            }

            if (type.IsEnum)
            {
                var opsImpl = typeof(Enum).MakeGenericType(type);
                foreach (var op in opsImpl.GetMethods(OpsHelper.BindingFlags))
                {
                    local.Add(op.Name);
                }
                info = info.Concat(opsImpl.GetMethods(OpsHelper.BindingFlags)).ToArray();

                // only [Flags] enums support bitwise operations
                if (type.IsFlagsEnum())
                {
                    opsImpl = typeof(FlagEnumOps<>).MakeGenericType(type);
                    foreach (var op in opsImpl.GetMethods(OpsHelper.BindingFlags))
                    {
                        local.Add(op.Name);
                    }
                    info = info.Concat(opsImpl.GetMethods(OpsHelper.BindingFlags)).ToArray();
                }
            }

            // Now again to filter w/o losing overloaded member info
            for (i = 0; i < info.Length; i++)
            {
                m = info[i];
                if (local.Contains(m.Name))
                {
                    items.Add(m);
                }
            }

            if (type.IsInterface)
            {
                // Interface inheritance seems to be a different animal:
                // more contractual, less structural.  Thus, a Type that
                // represents an interface that inherits from another
                // interface does not return the inherited interface's
                // methods in GetMembers. For example ICollection inherits
                // from IEnumerable, but ICollection's GetMemebers does not
                // return GetEnumerator.
                //
                // Not sure if this is the correct way to fix this, but it
                // seems to work. Thanks to Bruce Dodson for the fix.

                Type[] inheritedInterfaces = type.GetInterfaces();

                for (i = 0; i < inheritedInterfaces.Length; ++i)
                {
                    Type inheritedType = inheritedInterfaces[i];
                    MemberInfo[] imembers = inheritedType.GetMembers(BindingFlags);
                    for (n = 0; n < imembers.Length; n++)
                    {
                        m = imembers[n];
                        if (!local.Contains(m.Name))
                        {
                            items.Add(m);
                        }
                    }
                }

                // All interface implementations inherit from Object,
                // but GetMembers don't return them either.
                var objFlags = BindingFlags.Public | BindingFlags.Instance;
                foreach (var mi in typeof(object).GetMembers(objFlags))
                {
                    if (!local.Contains(mi.Name) && (mi as ConstructorInfo) == null)
                    {
                        items.Add(mi);
                    }
                }
            }

            for (i = 0; i < items.Count; i++)
            {
                var mi = (MemberInfo)items[i];

                switch (mi.MemberType)
                {
                    #region Method

                    case MemberTypes.Method:
                        meth = (MethodInfo)mi;
                        if (!ShouldBindMethod(meth))
                        {
                            continue;
                        }
                        name = meth.Name;

                        //TODO mangle?
                        if (name == "__init__" && impl != null && !impl.HasCustomNew())
                            continue;

                        if (!methods.TryGetValue(name, out var methodList))
                        {
                            methodList = methods[name] = new List<MethodBase>();
                        }
                        methodList.Add(meth);
                        continue;

                    #endregion

                    #region Constructor
                    case MemberTypes.Constructor when (impl != null && !impl.HasCustomNew()):
                        var ctor = (ConstructorInfo)mi;
                        if (ctor.IsStatic)
                        {
                            continue;
                        }

                        name = "__init__";
                        if (!methods.TryGetValue(name, out methodList))
                        {
                            methodList = methods[name] = new List<MethodBase>();
                        }
                        methodList.Add(ctor);
                        continue;
                    #endregion

                    #region Property
                    case MemberTypes.Property:
                        var pi = (PropertyInfo)mi;

                        if (!ShouldBindProperty(pi))
                        {
                            continue;
                        }

                        // Check for indexer
                        ParameterInfo[] args = pi.GetIndexParameters();

                        if (args.GetLength(0) > 0)
                        {
#if Indexer
                            Indexer? idx = ci.indexer;
                            if (idx == null)
                            {
                                ci.indexer = new Indexer();
                                idx = ci.indexer;
                            }
                            idx.AddProperty(pi);
#endif
                            continue;
                        }

                        ob = new PropertyObject(pi);
                        ci.members[pi.Name] = ob.AllocObject();
                        continue;

                    #endregion

                    #region Field
                    case MemberTypes.Field:
                        var fi = (FieldInfo)mi;
                        if (!ShouldBindField(fi))
                        {
                            continue;
                        }
                        ob = new FieldObject(fi);
                        ci.members[mi.Name] = ob.AllocObject();
                        continue;
                    #endregion

                    #region Event
                    case MemberTypes.Event:
                        var ei = (EventInfo)mi;
                        if (!ShouldBindEvent(ei))
                        {
                            continue;
                        }
                        ob = ei.AddMethod.IsStatic
                            ? (ExtensionType)new EventBinding(ei)
                            : new EventObject(ei);
                        ci.members[ei.Name] = ob.AllocObject();
                        continue;
                        #endregion

#if NestedType
                    case MemberTypes.NestedType:
                        tp = (Type)mi;
                        if (!(tp.IsNestedPublic || tp.IsNestedFamily ||
                              tp.IsNestedFamORAssem))
                        {
                            continue;
                        }
                        // Note the given instance might be uninitialized
                        var pyType = GetClass(tp);
                        // make a copy, that could be disposed later
                        ci.members[mi.Name] = new ReflectedClrType(pyType);
                        continue;
#endif
                }
            }

            foreach (var iter in methods)
            {
                name = iter.Key;
                MethodBase[] mlist = iter.Value.ToArray();

                ob = new MethodObject(type, name, mlist);
                ci.members[name] = (MethodObject)ob.AllocObject();

#if false

                if (mlist.Any(OperatorMethod.IsOperatorMethod))
                {
                    string pyName = OperatorMethod.GetPyMethodName(name);
                    string pyNameReverse = OperatorMethod.ReversePyMethodName(pyName);
                    OperatorMethod.FilterMethods(mlist, out var forwardMethods, out var reverseMethods);
                    // Only methods where the left operand is the declaring type.
                    if (forwardMethods.Length > 0)
                        ci.members[pyName] = new MethodObject(type, name, forwardMethods).AllocObject();
                    // Only methods where only the right operand is the declaring type.
                    if (reverseMethods.Length > 0)
                        ci.members[pyNameReverse] = new MethodObject(type, name, reverseMethods).AllocObject();
                }

#endif
            }

#if false
            if (ci.indexer == null && type.IsClass)
            {
                // Indexer may be inherited.
                var parent = type.BaseType;
                while (parent != null && ci.indexer == null)
                {
                    foreach (var prop in parent.GetProperties())
                    {
                        var args = prop.GetIndexParameters();
                        if (args.GetLength(0) > 0)
                        {
                            ci.indexer = new Indexer();
                            ci.indexer.AddProperty(prop);
                            break;
                        }
                    }
                    parent = parent.BaseType;
                }
            }
#endif

            return ci;
        }


#if false
        private static ClassInfo GetClassInfo(Type type)
        {
            ClassInfo ci = new ClassInfo();
            Hashtable methods = new Hashtable();
            ArrayList list;
            MethodInfo meth;
            ManagedType ob;
            String name;
            Object item;
            Type tp;
            int i, n;

            // This is complicated because inheritance in Python is name
            // based. We can't just find DeclaredOnly members, because we
            // could have a base class A that defines two overloads of a
            // method and a class B that defines two more. The name-based
            // descriptor Python will find needs to know about inherited
            // overloads as well as those declared on the sub class.

            BindingFlags flags = BindingFlags.Static |
                             BindingFlags.Instance |
                                 BindingFlags.Public |
                                     BindingFlags.NonPublic;

            MemberInfo[] info = type.GetMembers(flags);
            Hashtable local = new Hashtable();
            ArrayList items = new ArrayList();
            MemberInfo m;

            // Loop through once to find out which names are declared
            for (i = 0; i < info.Length; i++)
            {
                m = info[i];
                if (m.DeclaringType == type)
                {
                    local[m.Name] = 1;
                }
            }

            // Now again to filter w/o losing overloaded member info
            for (i = 0; i < info.Length; i++)
            {
                m = info[i];
                if (local[m.Name] != null)
                {
                    items.Add(m);
                }
            }

            if (type.IsInterface)
            {
                // Interface inheritance seems to be a different animal:
                // more contractual, less structural.  Thus, a Type that
                // represents an interface that inherits from another
                // interface does not return the inherited interface's
                // methods in GetMembers. For example ICollection inherits
                // from IEnumerable, but ICollection's GetMemebers does not
                // return GetEnumerator.
                //
                // Not sure if this is the correct way to fix this, but it
                // seems to work. Thanks to Bruce Dodson for the fix.

                Type[] inheritedInterfaces = type.GetInterfaces();

                for (i = 0; i < inheritedInterfaces.Length; ++i)
                {
                    Type inheritedType = inheritedInterfaces[i];
                    MemberInfo[] imembers = inheritedType.GetMembers(flags);
                    for (n = 0; n < imembers.Length; n++)
                    {
                        m = imembers[n];
                        if (local[m.Name] == null)
                        {
                            items.Add(m);
                        }
                    }
                }
            }

            for (i = 0; i < items.Count; i++)
            {

                MemberInfo mi = (MemberInfo)items[i];

                switch (mi.MemberType)
                {

                    #region Method
                    case MemberTypes.Method:
                        meth = (MethodInfo)mi;
                        if (!(meth.IsPublic || meth.IsFamily ||
                          meth.IsFamilyOrAssembly))
                            continue;
                        name = meth.Name;
                        item = methods[name];
                        if (item == null)
                        {
                            item = methods[name] = new ArrayList();
                        }
                        list = (ArrayList)item;
                        list.Add(meth);
                        continue;
                    #endregion

                    #region Property

                    case MemberTypes.Property:
                        PropertyInfo pi = (PropertyInfo)mi;

                        MethodInfo mm = null;
                        try
                        {
                            mm = pi.GetGetMethod(true);
                            if (mm == null)
                            {
                                mm = pi.GetSetMethod(true);
                            }
                        }
                        catch (SecurityException)
                        {
                            // GetGetMethod may try to get a method protected by
                            // StrongNameIdentityPermission - effectively private.
                            continue;
                        }

                        if (mm == null)
                        {
                            continue;
                        }

                        if (!(mm.IsPublic || mm.IsFamily || mm.IsFamilyOrAssembly))
                            continue;

                        // Check for indexer
                        ParameterInfo[] args = pi.GetIndexParameters();
                        if (args.GetLength(0) > 0)
                        {
                            Indexer idx = ci.indexer;
                            if (idx == null)
                            {
                                ci.indexer = new Indexer();
                                idx = ci.indexer;
                            }
                            idx.AddProperty(pi);
                            continue;
                        }

                        ob = new PropertyObject(pi);
                        ci.members[pi.Name] = ob;
                        continue;

                    #endregion

                    #region Field
                    case MemberTypes.Field:
                        FieldInfo fi = (FieldInfo)mi;
                        if (!(fi.IsPublic || fi.IsFamily || fi.IsFamilyOrAssembly))
                            continue;
                        ob = new FieldObject(fi);
                        ci.members[mi.Name] = ob;
                        continue;
                    #endregion

                    case MemberTypes.Event:
                        EventInfo ei = (EventInfo)mi;
                        MethodInfo me = ei.GetAddMethod(true);
                        if (!(me.IsPublic || me.IsFamily || me.IsFamilyOrAssembly))
                            continue;
                        ob = new EventObject(ei);
                        ci.members[ei.Name] = ob;
                        continue;

                    case MemberTypes.NestedType:
                        tp = (Type)mi;
                        if (!(tp.IsNestedPublic || tp.IsNestedFamily ||
                          tp.IsNestedFamORAssem))
                            continue;
                        ob = ClassManager.GetClass(tp);
                        ci.members[mi.Name] = ob;
                        continue;

                }
            }

            IDictionaryEnumerator iter = methods.GetEnumerator();

            while (iter.MoveNext())
            {
                name = (string)iter.Key;
                list = (ArrayList)iter.Value;

                MethodInfo[] mlist = (MethodInfo[])list.ToArray(
                                   typeof(MethodInfo)
                                   );

                ob = new MethodObject(name, mlist);
                ci.members[name] = ob;
            }

            return ci;

        }

#endif
    }


}
