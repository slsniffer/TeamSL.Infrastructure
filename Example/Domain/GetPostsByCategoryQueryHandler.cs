using System.Collections.Generic;
using System.Linq;
using TeamSL.Infrastructure.Data;
using TeamSL.Infrastructure.Data.Specifications;
using TeamSL.Infrastructure.Domain.Caching;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Example
{
    [CacheQuery]
    public class GetPostsByCategoryQuery : IQuery<IList<PostRecord>>
    {
        [CacheKey]
        public long CategoryId { get; set; }

        public GetPostsByCategoryQuery(long categoryId)
        {
            CategoryId = categoryId;
        }
    }

    public class PostsByCategorySpecification : IQuerySpecification<PostRecord>
    {
        private readonly long _categoryId;

        public PostsByCategorySpecification(long categoryId)
        {
            _categoryId = categoryId;
        }

        public IQueryable<PostRecord> SatisfyingElementsFrom(IQueryable<PostRecord> candidates)
        {
            return candidates.Where(x => x.CategoryId == _categoryId);
        }
    }

    public class GetPostsByCategoryQueryHandler : IQueryHandler<GetPostsByCategoryQuery, IList<PostRecord>>
    {
        private readonly IReadRepository<PostRecord> _postRepository;

        public GetPostsByCategoryQueryHandler(IReadRepository<PostRecord> postRepository)
        {
            _postRepository = postRepository;
        }

        public IList<PostRecord> Ask(GetPostsByCategoryQuery query)
        {
            return _postRepository.FindAll(new PostsByCategorySpecification(query.CategoryId));
        }
    }
}