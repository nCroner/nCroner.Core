using System;
using System.Collections.Generic;

namespace nCroner.Core.Models
{
    public class TypeDataModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public Dictionary<string, string> Input { get; set; }
        public Dictionary<string, string> Output { get; set; }
    }
}