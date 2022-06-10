using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nCroner.Common.Models;

namespace nCroner.Common.Actions
{
    public interface IAction : IDisposable
    {
        Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);
    }
}