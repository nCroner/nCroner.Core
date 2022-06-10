using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nCroner.Core.Models;

namespace nCroner.Core.Actions
{
    public interface IAction : IDisposable
    {
        Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);
    }
}