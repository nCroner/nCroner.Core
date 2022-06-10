using System.Collections.Generic;

namespace nCroner.Core.Models
{
    public class EventResponse
    {
        public bool CanContinue { get;  }
        public IDictionary<string, object> Data { get;  }

        public EventResponse(bool canContinue, IDictionary<string, object> data)
        {
            CanContinue = canContinue;
            Data = data;
        }
    }
}