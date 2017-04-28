using System.Reflection;
using Autofac;
using TeamSL.Infrastructure.Domain.Caching;
using TeamSL.Infrastructure.Domain.Commands;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Domain.Autofac
{
    public class InfrastructureDomainRegistration
    {
        public static void Register(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterType<AutofacQueryHandlerFactory>().As<IQueryHandlerFactory>();
            builder.RegisterType<AutofacCommandHandlerFactory>().As<ICommandHandlerFactory>();

            var cmdHandlerType = typeof(ICommandHandler<>);
            builder.RegisterGenericHandlers(assembly, cmdHandlerType, "commandHandlers1");
            builder.RegisterGenericDecorator(typeof(CommandHandlerLoggingDecorator<>), cmdHandlerType, "commandHandlers1", "commandHandlers2");
            builder.RegisterGenericDecorator(typeof(CommandHandlerCachingDecorator<>), cmdHandlerType, "commandHandlers2");

            var qHandlerType = typeof(IQueryHandler<,>);
            builder.RegisterGenericHandlers(assembly, qHandlerType, "queryHandlers");
            builder.RegisterGenericDecorator(typeof(QueryHandlerLoggingDecorator<,>), qHandlerType, "queryHandlers1", "queryHandlers2");
            builder.RegisterGenericDecorator(typeof(QueryHandlerCachingDecorator<,>), qHandlerType, "queryHandlers2");

            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>();
            builder.RegisterType<DefaultQueryGateway>().As<IQueryGateway>();

            builder.RegisterType<QueryCacheKeyBuilder>().As<IQueryCacheKeyBuilder>();
            builder.RegisterType<QueryCacheObserver>().As<IQueryCacheObserver>().SingleInstance();

        }
    }

    public static class InfrastructureDomainExtensions
    {
        public static void RegisterQueryHandlers(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterType<AutofacQueryHandlerFactory>().As<IQueryHandlerFactory>();

            var qHandlerType = typeof(IQueryHandler<,>);
            builder.RegisterGenericHandlers(assembly, qHandlerType, "queryHandlers1");
            builder.RegisterGenericDecorator(typeof(QueryHandlerLoggingDecorator<,>), qHandlerType, "queryHandlers1", "queryHandlers2");
            builder.RegisterGenericDecorator(typeof(QueryHandlerCachingDecorator<,>), qHandlerType, "queryHandlers2");

            builder.RegisterType<DefaultQueryGateway>().As<IQueryGateway>();
        }

        public static void RegisterCommandHandlers(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterType<AutofacCommandHandlerFactory>().As<ICommandHandlerFactory>();
            
            var cmdHandlerType = typeof(ICommandHandler<>);
            builder.RegisterGenericHandlers(assembly, cmdHandlerType, "commandHandlers1");
            builder.RegisterGenericDecorator(typeof(CommandHandlerLoggingDecorator<>), cmdHandlerType, "commandHandlers1", "commandHandlers2");
            builder.RegisterGenericDecorator(typeof(CommandHandlerCachingDecorator<>), cmdHandlerType, "commandHandlers2");

            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>();
        }
    }
}