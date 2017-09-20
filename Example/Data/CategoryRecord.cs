using System.Collections.Generic;
using TeamSL.Infrastructure.Data.NHibernate;

namespace TeamSL.Infrastructure.Example.Data
{
    public class CategoryRecord : NhRecord
    {
        public virtual string Name { get; set; }
        public virtual ISet<PostRecord> Posts { get; set; }
    }
}