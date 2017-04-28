using Autofac;

namespace TeamSL.Infrastructure.Data.NHibernate.Autofac
{
    public static class InfrastructureDataExtensions
    {
        public static void RegisterNHibernate(this ContainerBuilder builder)
        {
            builder.Register(x => x.Resolve<INHibernateInitializer>().GetConfiguration().BuildSessionFactory()).SingleInstance();
        }

        public static void RegisterUnitOfWork(this ContainerBuilder builder)
        {
            builder.RegisterType<NHibernateUnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.RegisterType<NHibernateUnitOfWork>().As<IUnitOfWork>();
        }

        public static void RegisterPerRequestSessionProvider(this ContainerBuilder builder)
        {
            builder.RegisterType<PerRequestSessionProvider>().As<ISessionProvider>().InstancePerRequest();
        }

        public static void RegisterStaticSessionProvider(this ContainerBuilder builder)
        {
            builder.RegisterType<StaticSessionProvider>().As<ISessionProvider>().InstancePerDependency();
        }

        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            var writeRepositoryType = typeof(IRepository<>);
            var readRepositoryType = typeof(IReadRepository<>);

            var writeRepositoryKey = "writeRepository";
            var readRepositoryKey = "readRepository";
            builder.RegisterGeneric(typeof(NHibernateRepository<>)).Named(readRepositoryKey, readRepositoryType);
            builder.RegisterGeneric(typeof(NHibernateRepository<>)).Named(writeRepositoryKey, writeRepositoryType);
            builder.RegisterGenericDecorator(typeof(ReadRepositoryLoggingDecorator<>), readRepositoryType, readRepositoryKey);
            builder.RegisterGenericDecorator(typeof(RepositoryLoggingDecorator<>), writeRepositoryType, writeRepositoryKey);

            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
        }
    }
}
