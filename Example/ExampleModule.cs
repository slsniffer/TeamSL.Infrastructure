using Autofac;
using TeamSL.Infrastructure.Data.NHibernate;
using TeamSL.Infrastructure.Domain;
using TeamSL.Infrastructure.Domain.Caching;
using TeamSL.Infrastructure.Example.Data;
using Module = Autofac.Module;

namespace TeamSL.Infrastructure.Example
{
    public class ExampleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Registration demo services.
            builder.RegisterType<Presenter>().As<IPresenter>();
            builder.RegisterType<DbCreator>().As<IDbCreator>();
            builder.RegisterType<DbConfiguration>().As<IDbConfiguration>();

            // Registration database infrastructure.
            builder.RegisterNHibernate();
            builder.RegisterRepositories();
            builder.RegisterType<StaticSessionProvider>().As<ISessionProvider>();
            builder.RegisterType<NHibernateInitializer>().As<INHibernateInitializer>();

            // Register domain infrastructure.
            builder.RegisterQueryHandlers(GetType().Assembly);
            builder.RegisterCommandHandlers(GetType().Assembly);
            builder.RegisterMemoryCaching();
            builder.RegisterType<NullCacheConfiguration>().As<ICacheConfiguration>();

            // Reister logging.
            builder.RegisterModule<LoggingModule>();
        }
    }
}