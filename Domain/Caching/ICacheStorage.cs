using System;
using System.Runtime.Caching;
using TeamSL.Infrastructure.Domain.Commands;

namespace TeamSL.Infrastructure.Domain.Caching
{
    public interface ICacheStorage
    {
        T Get<T>(string key);
        bool TryGet<T>(string key, out T value);
        void Set<T>(string key, T value);
        void Set<T>(string key, T value, DateTime absoluteExpiration);
        void Set<T>(string key, T value, TimeSpan slidingExpiration);
        void Remove(string key);
        MemoryCache Cache { get; }
    }

    public interface INotify<TCommand> where TCommand : ICommand
    {
    }
}