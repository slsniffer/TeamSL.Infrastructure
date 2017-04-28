using TeamSL.Infrastructure.Data;
using TeamSL.Infrastructure.Domain.Caching;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Example
{
    [CacheQuery]
    public class GetPostByIdQuery : IQuery<PostRecord>
    {
        [CacheKey]
        public long PostId { get; set; }

        public GetPostByIdQuery(long postId)
        {
            PostId = postId;
        }
    }

    public class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostRecord>
    {
        private readonly IReadRepository<PostRecord> _postRepository;

        public GetPostByIdQueryHandler(IReadRepository<PostRecord> postRepository)
        {
            _postRepository = postRepository;
        }

        public PostRecord Ask(GetPostByIdQuery query)
        {
            return _postRepository.Load(query.PostId);
        }
    }
}