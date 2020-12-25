using nCroner.Common.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace nCroner.Common.Operations
{
    public abstract class OperationCollection
    {
        protected OperationCollection()
        {
            Operations = new List<TypeDataModel>();
        }

        public abstract Guid Id { get; }
        public abstract string Title { get; }

        public List<TypeDataModel> Operations { get; }

        public virtual void Init(IServiceCollection services)
        {

        }
        
        protected void AddOperation<T>(Guid id, string title)
            where T : IOperation
        {
            Operations.Add(new TypeDataModel()
            {
                Id = id,
                Title = title,
                Type = typeof(T)
            });
        }

    }
}