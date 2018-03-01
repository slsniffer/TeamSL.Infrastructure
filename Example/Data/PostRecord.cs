using TeamSL.Infrastructure.Data;

namespace TeamSL.Infrastructure.Example.Data
{
    public class PostRecord : Record
    {
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual CategoryRecord Category { get; set; }
    }
}