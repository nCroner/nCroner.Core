using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using nCroner.Common.Actions;
using nCroner.Common.Models;
using nCroner.Common.Triggers;

namespace nCroner.Common.Plugins
{
    public interface IPlugin
    {
        string Title { get; }
        string Description { get; }
        
        /// <summary>
        /// Gets the interval in second
        /// </summary>
        int Interval { get; }
        
        IReadOnlyCollection<TriggerTypeDataModel> Triggers { get; }
        IReadOnlyCollection<TypeDataModel> Actions { get; }

        Stream GetThumbImage();

        void Init(IServiceCollection services);

        void AddEvent<T>(Guid id, string title, string eventRoute = "") where T : ITrigger;
        void AddMiddleware<T>(Guid id, string title) where T : IAction;
    }

    
}