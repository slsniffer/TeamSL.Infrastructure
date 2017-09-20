using TeamSL.Infrastructure.Data;
using TeamSL.Infrastructure.Domain.Commands;
using TeamSL.Infrastructure.Example.Data;

namespace TeamSL.Infrastructure.Example.Domain
{
    public class CreatePostCommand : ICommand
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public long CategoryId { get; set; }

        public CreatePostCommand(string title, string body, long categoryId)
        {
            Title = title;
            Body = body;
            CategoryId = categoryId;
        }
    }

    /// <summary>
    /// Command handler for post creation.
    /// </summary>
    public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
    {
        private readonly IRepository<PostRecord> _postRepository;

        public CreatePostCommandHandler(IRepository<PostRecord> postRepository)
        {
            _postRepository = postRepository;
        }

        public void Execute(CreatePostCommand command)
        {
            _postRepository.Create(new PostRecord {Title = command.Title, Body = command.Body, Category = new CategoryRecord {Id = command.CategoryId}});
        }
    }
}