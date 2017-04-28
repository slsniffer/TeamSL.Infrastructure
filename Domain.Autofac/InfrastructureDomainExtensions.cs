using System.Reflection;
using Autofac;
using TeamSL.Infrastructure.Domain.Caching;
using TeamSL.Infrastructure.Domain.Commands;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Domain.Autofac
{
    public static class InfrastructureDomainExtensions
    {
        public static void RegisterQueryHandlers(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterType<AutofacQueryHandlerFactory>().As<IQueryHandlerFactory>();

            var qHandlerType = typeof(IQueryHandler<,>);
            builder.RegisterGenericHandlers(assembly, qHandlerType, "queryHandlers1");
            builder.RegisterGenericDecorator(typeof(QueryHandlerLoggingDecorator<,>), qHandlerType, "queryHandlers1", "queryHandlers2");
            builder.RegisterGenericDecorator(typeof(QueryHandlerCachingDecorator<,>), qHandlerType, "queryHandlers2");

            builder.RegisterType<AutofacQueryGateway>().As<IQueryGateway>();
        }

        public static void RegisterCommandHandlers(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterType<AutofacCommandHandlerFactory>().As<ICommandHandlerFactory>();
            
            var cmdHandlerType = typeof(ICommandHandler<>);
            builder.RegisterGenericHandlers(assembly, cmdHandlerType, "commandHandlers");
            builder.RegisterGenericDecorator(typeof(CommandHandlerLoggingDecorator<>), cmdHandlerType, "commandHandlers");

            builder.RegisterType<DefaultCommander>().As<ICommander>();
        }

        public static void RegisterMemoryCaching(this ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCacheStorage>().As<ICacheStorage>();
            builder.RegisterType<QueryCacheKeyBuilder>().As<IQueryCacheKeyBuilder>();
        }
    }
}