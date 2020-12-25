using nCroner.Common.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace nCroner.Common.Events
{
    public abstract class EventCollection
    {
        protected EventCollection()
        {
            Events = new List<EventTypeDataModel>();
        }

        public abstract Guid Id { get; }
        public abstract string Title { get; }

        /// <summary>
        /// Gets the interval in second
        /// </summary>
        public abstract int Interval { get; }

        public List<EventTypeDataModel> Events { get; }

        public virtual void Init(IServiceCollection services)
        {

        }

        protected void AddEvent<T>(Guid id, string title, string eventRoute = "")
            where T : IEvent
        {
            Events.Add(new EventTypeDataModel()
            {
                Id = id,
                Title = title,
                Type = typeof(T),
                EventRoute = eventRoute.ToLower()
            });
        }
    }
}