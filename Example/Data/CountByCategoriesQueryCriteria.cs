using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using NHibernate.Type;
using TeamSL.Infrastructure.Data.NHibernate;

namespace TeamSL.Infrastructure.Example.Data
{
    public class CountByCategoriesQueryCriteria : BaseQueryCriteria<IList<CategoryDto>>
    {
        public override void Initialize(ISession session)
        {
            _criteria = session.CreateCriteria<CategoryRecord>("c");
            _criteria.CreateAlias("Posts", "p");

            _criteria.SetProjection(
                Projections.ProjectionList()
                    .Add(Projections.GroupProperty("c.Id"), "CategoryId")
                    .Add(Projections.GroupProperty("c.Name"), "CategoryName")
                    .Add(Projections.RowCount(), "CategoryPosts"));

            _criteria.AddOrder(Order.Asc("CategoryId"));
        }

        public override IList<CategoryDto> Get()
        {
            _criteria.SetResultTransformer(Transformers.AliasToBean(typeof(CategoryDto)));
            var categoryDtos = _criteria.List<CategoryDto>();
            return categoryDtos;
        }
    }
}