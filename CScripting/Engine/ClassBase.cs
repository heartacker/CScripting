
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CScriptingEngine
{
    internal class ClassBase : ManagedType, IDeserializationCallback
    {
        internal List<string> dotNetMembers = new List<string>();
        // internal Indexer? indexer;
        internal readonly Dictionary<int, MethodObject> richcompare = new Dictionary<int, MethodObject>();
        internal Type type;

        internal ClassBase(Type tp)
        {
            if (tp is null) throw new ArgumentNullException(nameof(type));

            // indexer = null;
            type = tp;
        }

        internal virtual bool CanSubclass()
        {
            return false;
            // return !type.Value.IsEnum;
        }

        public void OnDeserialization(object sender)
        {
            throw new global::System.NotImplementedException();
        }

        internal bool HasCustomNew()
        {
            throw new NotImplementedException();
        }
    }
}