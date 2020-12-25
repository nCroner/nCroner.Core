using LiteDB;
using System;

namespace nCroner.Common.Tools
{
    public interface IDb : IDisposable
    {
        ILiteCollection<T> GetCollection<T>(Guid id, string name);
    }
}