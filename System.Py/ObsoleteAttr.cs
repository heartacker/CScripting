using System;

namespace Internal.Py.Attributes
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event |
    AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    internal sealed class ObsoleteAttribute : Attribute
    {
        public ObsoleteAttribute() { }
        public ObsoleteAttribute(string message) { }
        public ObsoleteAttribute(string message, bool error) { }

        public bool IsError { get; }
        public string Message { get; }
    }
}