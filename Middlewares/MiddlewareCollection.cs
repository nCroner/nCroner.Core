using nCroner.Common.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace nCroner.Common.Middlewares
{
    public abstract class MiddlewareCollection
    {
        protected MiddlewareCollection()
        {
            Middlewares = new List<TypeDataModel>();
        }

        public List<TypeDataModel> Middlewares { get; }

        public virtual void Init(IServiceCollection services)
        {

        }

        protected void AddMiddleware<T>(Guid id, string title)
            where T : IMiddleware
        {
            Middlewares.Add(new TypeDataModel()
            {
                Id = id,
                Title = title,
                Type = typeof(T)
            });
        }

    }
}