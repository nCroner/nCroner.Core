using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nCroner.Common.Models;

namespace nCroner.Common.Actions
{
    public abstract class Action : IAction
    {
        #region Abstract Methods

        public abstract void Dispose();

        public abstract Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);

        #endregion
        
        #region Protected Methods

        protected Task<EventResponse> Stop =>
            Task.FromResult(new EventResponse(false, new Dictionary<string, object>(0)));

        protected Task<EventResponse> Continue(IDictionary<string, object> data)
        {
            return Task.FromResult(new EventResponse(true, data));
        }

        protected Task<EventResponse> Continue()
        {
            return Task.FromResult(new EventResponse(true, new Dictionary<string, object>(0)));
        }

        #endregion
        
    }
}