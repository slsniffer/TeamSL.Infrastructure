namespace TeamSL.Infrastructure.Data
{
    public interface IRepository<in TRecord> where TRecord : Record
    {
        void Create(TRecord record);
        void Update(TRecord record);
        void CreateOrUpdate(TRecord record);
        void Delete(TRecord record);
    }
}
