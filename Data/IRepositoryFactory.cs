namespace TeamSL.Infrastructure.Data
{
    public interface IRepositoryFactory
    {
        IReadRepository<TRecord> Read<TRecord>() where TRecord : Record;
        IRepository<TRecord> Write<TRecord>() where TRecord : Record;
    }
}