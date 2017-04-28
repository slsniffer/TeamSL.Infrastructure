using System;

namespace TeamSL.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Save<TRecord>(TRecord record) where TRecord : Record;

        void Delete<TRecord>(TRecord record) where TRecord : Record;
    }
}
