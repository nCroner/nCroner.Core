using System;
using System.Collections.Generic;

namespace nCroner.Core.Tools
{
    public interface IUtility
    {
        string GetWebHookUrl(string hook);

        void ContinueEvent(Guid id, Dictionary<string, object> parameters);
    }
}