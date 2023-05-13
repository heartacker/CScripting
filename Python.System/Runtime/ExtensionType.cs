using System;
using System.Reflection;

using System = System;

namespace Python
{
    internal class ExtensionType
    {
        private EventInfo ei;

        public ExtensionType(EventInfo ei = null)
        {
            this.ei = ei;
        }

        internal virtual object AllocObject()
        {
            return this;
        }

    }
    internal class PropertyObject : ExtensionType
    {
        private PropertyInfo pi;

        public PropertyObject(PropertyInfo pi)
        {
            this.pi = pi;
        }
    }

    internal class MethodObject : ExtensionType
    {
        private Type type;
        public string name;
        public MethodBase[] mlist;

        public MethodObject(Type type, string name, MethodBase[] mlist)
        {
            this.type = type;
            this.name = name;
            this.mlist = mlist;
        }
        internal new object AllocObject()
        {
            return this;
        }
    }

    internal class FieldObject : ExtensionType
    {
        public FieldInfo fi;

        public FieldObject(FieldInfo fi)
        {
            this.fi = fi;
        }
        internal override object AllocObject()
        {
            return this;
            // todo 
            // FIXME
            object instance = Activator.CreateInstance(fi.DeclaringType); // 使用反射创建实例
            return instance;
        }
    }

    internal class EventObject : ExtensionType
    {
        public EventObject(EventInfo ei) : base(ei)
        {
        }
    }
    internal class EventBinding : ExtensionType
    {

        public EventBinding(EventInfo ei) : base(ei)
        {

        }

    }

}