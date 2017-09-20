using FluentNHibernate.Mapping;

namespace TeamSL.Infrastructure.Example.Data
{
    public class PostRecordMap : ClassMap<PostRecord>
    {
        public PostRecordMap()
        {
            Table("Posts");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title).Not.Nullable();
            Map(x => x.Body).Not.Nullable();
            References(x => x.Category, "CategoryId").Not.Nullable();
        }
    }
}