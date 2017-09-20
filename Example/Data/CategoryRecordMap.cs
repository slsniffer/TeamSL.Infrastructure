using FluentNHibernate.Mapping;

namespace TeamSL.Infrastructure.Example.Data
{
    public class CategoryRecordMap : ClassMap<CategoryRecord>
    {
        public CategoryRecordMap()
        {
            Table("Categories");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            HasMany(x => x.Posts).AsSet();
        }
    }
}