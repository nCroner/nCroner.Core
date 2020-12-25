using System;

namespace nCroner.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class OutputAttribute : Attribute
    {
        public string Key { get; }
        public string Description { get; }

        public OutputAttribute(string key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}