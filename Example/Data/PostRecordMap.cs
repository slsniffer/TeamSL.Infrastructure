using FluentNHibernate.Mapping;

namespace TeamSL.Infrastructure.Example
{
    public class PostRecordMap : ClassMap<PostRecord>
    {
        public PostRecordMap()
        {
            Table("Posts");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title).Not.Nullable();
            Map(x => x.Body).Not.Nullable();
        }
    }
}