using System.Collections.Generic;

namespace nCroner.Common.Models
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