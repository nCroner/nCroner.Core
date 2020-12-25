using nCroner.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nCroner.Common.Middlewares
{
    public interface IMiddleware : IDisposable
    {
        //Guid Id { get; }
        //string Title { get; }

        Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);

    }
}