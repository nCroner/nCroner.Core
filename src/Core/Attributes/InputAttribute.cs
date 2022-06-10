using System;

namespace nCroner.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InputAttribute : Attribute
    {
        public string Key { get; }
        public string Description { get; }

        public InputAttribute(string key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}