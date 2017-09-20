using System.Collections.Generic;
using TeamSL.Infrastructure.Data.NHibernate;
using TeamSL.Infrastructure.Domain.Queries;
using TeamSL.Infrastructure.Example.Data;

namespace TeamSL.Infrastructure.Example.Domain
{
    public class CountByCategoriesQuery : IQuery<IList<CategoryDto>>
    {
    }

    public class CountByCategoriesQueryHandler : IQueryHandler<CountByCategoriesQuery, IList<CategoryDto>>
    {
        private readonly IContentReader _contentReader;

        public CountByCategoriesQueryHandler(IContentReader contentReader)
        {
            _contentReader = contentReader;
        }

        public IList<CategoryDto> Ask(CountByCategoriesQuery query)
        {
            return _contentReader.Read(new CountByCategoriesQueryCriteria());
        }
    }
}