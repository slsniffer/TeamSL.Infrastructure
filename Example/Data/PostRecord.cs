using TeamSL.Infrastructure.Data.NHibernate;

namespace TeamSL.Infrastructure.Example
{
    public class PostRecord : NhRecord
    {
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual long CategoryId { get; set; }
    }
}