using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nCroner.Core.Models;

namespace nCroner.Core.Triggers
{
    public interface ITrigger : IDisposable
    {
        void EventInit(Guid id, Dictionary<string,object> input);

        Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);
    }
}
