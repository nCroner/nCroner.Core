using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nCroner.Common.Operations
{
    public interface IOperation : IDisposable
    {
        //Guid Id { get; }
        //string Title { get; }

        Task DoWork(Guid id, IDictionary<string, object> input);
    }
}