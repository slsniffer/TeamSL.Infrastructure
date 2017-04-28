using TeamSL.Infrastructure.Domain.Commands;
using TeamSL.Infrastructure.Domain.Queries;
using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Example
{
    public interface IPresenter
    {
        void Show();
    }

    public class Presenter : IPresenter
    {
        private readonly IQueryGateway _gateway;
        private readonly ICommander _commander;

        public ILogger Logger { get; set; }

        public Presenter(IQueryGateway gateway, ICommander commander)
        {
            _gateway = gateway;
            _commander = commander;
        }

        public void Show()
        {
            // Create three posts in database.
            _commander.Send(new CreatePostCommand("First post title", "First post body", 1));
            _commander.Send(new CreatePostCommand("Second post title", "Second post body", 2));
            _commander.Send(new CreatePostCommand("Third post title", "Third post body", 1));
            Logger.DebugCustom("Add three posts finished.");

            // Read first post from database. Add to cache.
            var post = _gateway.Read(new GetPostByIdQuery(1));
            Logger.DebugCustom("Read first post and cached it.");

            // Read from cache first post.
            post = _gateway.Read(new GetPostByIdQuery(1));
            Logger.DebugCustom("Read first post from cache.");

            // Read all posts from database
            var posts = _gateway.Read(new GetAllPostsQuery());
            Logger.DebugCustom("Read all posts from specific category.");
        }
    }
}