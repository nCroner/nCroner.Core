using System.Collections.Generic;

namespace nCroner.Common.Models
{
    public class EventResponse
    {
        public bool Continue { get; set; } = true;
        public IDictionary<string, object> Data { get; set; }
    }
}