using System;

namespace nCroner.Common.Tools
{
    public interface ITaskRunner
    {
        void Add(Action action);
    }
}