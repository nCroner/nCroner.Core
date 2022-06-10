using LiteDB;
using System;

namespace nCroner.Core.Tools
{
    public interface IDb : IDisposable
    {
        ILiteCollection<T> GetCollection<T>(Guid id, string collectionName);

        ILiteCollection<T> GetGlobalCollection<T>(string name, string collectionName);
    }
}