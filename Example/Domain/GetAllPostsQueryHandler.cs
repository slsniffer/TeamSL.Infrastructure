using System.Collections.Generic;
using TeamSL.Infrastructure.Data;
using TeamSL.Infrastructure.Domain.Caching;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Example
{
    [CacheQuery]
    public class GetAllPostsQuery : IQuery<IList<PostRecord>>
    {
    }

    /// <summary>
    /// Query handler for reading all posts from database.
    /// </summary>
    public class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, IList<PostRecord>>
    {
        private readonly IReadRepository<PostRecord> _postRepository;

        public GetAllPostsQueryHandler(IReadRepository<PostRecord> postRepository)
        {
            _postRepository = postRepository;
        }

        public IList<PostRecord> Ask(GetAllPostsQuery query)
        {
            return _postRepository.FindAll();
        }
    }
}