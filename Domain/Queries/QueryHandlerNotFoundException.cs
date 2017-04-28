using System;

namespace TeamSL.Infrastructure.Domain.Queries
{
    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException(Type type)
            : base(string.Format("Query handler not found for query type: {0}", type))
        {
        }
    }
}
