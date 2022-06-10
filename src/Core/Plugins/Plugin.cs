using System;
using System.Collections.Generic;
using System.IO;
using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using nCroner.Core.Actions;
using nCroner.Core.Models;
using nCroner.Core.Triggers;

namespace nCroner.Core.Plugins
{
    public abstract class Plugin : IPlugin
    {
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract int Interval { get; }
        public abstract Stream GetThumbImage();

        public IReadOnlyCollection<TriggerTypeDataModel> Triggers => _events.AsReadOnly();
        public IReadOnlyCollection<TypeDataModel> Actions => _middlewares.AsReadOnly();

        private readonly List<TriggerTypeDataModel> _events;
        private readonly List<TypeDataModel> _middlewares;

        protected Plugin()
        {
            _events = new List<TriggerTypeDataModel>();
            _middlewares = new List<TypeDataModel>();
        }

        public abstract void Init(IServiceCollection services);

        public void AddEvent<T>(Guid id, string title, Schedule schedule = null, string eventRoute = "")
            where T : ITrigger
        {
            _events.Add(new TriggerTypeDataModel()
            {
                Id = id,
                Title = title,
                Type = typeof(T),
                TriggerRoute = eventRoute.ToLower(),
                Schedule = schedule
            });
        }

        public void AddMiddleware<T>(Guid id, string title) where T : IAction
        {
            _middlewares.Add(new TypeDataModel()
            {
                Id = id,
                Title = title,
                Type = typeof(T)
            });
        }
    }
}