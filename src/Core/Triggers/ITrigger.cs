using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nCroner.Common.Models;

namespace nCroner.Common.Triggers
{
    public interface ITrigger : IDisposable
    {
        //void EventInit(Guid id, Dictionary<string,object> input);

        Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);
    }
}
