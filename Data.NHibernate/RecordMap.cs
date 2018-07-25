using FluentNHibernate.Mapping;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public abstract class RecordMap<TRecord> : ClassMap<TRecord>
        where TRecord : Record
    {
        protected RecordMap(string tableName)
        {
            Table(tableName);
            Id(x => x.Id).GeneratedBy.Identity();
        }
    }
}