using System;
using NHibernate.Util;
using TeamSL.Infrastructure.Domain.Commands;
using TeamSL.Infrastructure.Domain.Queries;
using TeamSL.Infrastructure.Example.Domain;
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
            // Create categories.
            _commander.Send(new CreateCategoryCommand("Category 1"));
            _commander.Send(new CreateCategoryCommand("Category 2"));

            // Create three posts in database.
            _commander.Send(new CreatePostCommand("First post title", "First post body", 1));
            _commander.Send(new CreatePostCommand("Second post title", "Second post body", 2));
            _commander.Send(new CreatePostCommand("Third post title", "Third post body", 1));
            _commander.Send(new CreatePostCommand("Fourth post title", "Fourth post body", 1));
            Logger.DebugCustom("Add four posts finished.");

            // Read first post from database. Add to cache.
            var post = _gateway.Read(new GetPostByIdQuery(1));
            Logger.DebugCustom("Read first post and cached it.");

            // Read from cache first post.
            post = _gateway.Read(new GetPostByIdQuery(1));
            Logger.DebugCustom("Read first post from cache.");

            // Read all posts from database.
            var posts = _gateway.Read(new GetAllPostsQuery());
            Logger.DebugCustom("Read all posts.");

            // Calculate all posts by categories.
            var dtos = _gateway.Read(new CountByCategoriesQuery());
            dtos.ForEach(x => Logger.Debug($"{x.CategoryName} - {x.CategoryPosts}"));
        }
    }
}