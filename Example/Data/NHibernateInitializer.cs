using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using TeamSL.Infrastructure.Data.NHibernate;

namespace TeamSL.Infrastructure.Example
{
    public class NHibernateInitializer : INHibernateInitializer
    {
        public Configuration GetConfiguration()
        {
            var config = SQLiteConfiguration.Standard.UsingFile("test.db");

            var fluentConfiguration = Fluently.Configure()
                .Database(config)
                .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                .Cache(c => c.Not.UseSecondLevelCache().Not.UseQueryCache())
                .ExposeConfiguration(Expose);

            return fluentConfiguration.BuildConfiguration();
        }

        private static void Expose(Configuration cfg)
        {
            cfg.SetProperty(Environment.GenerateStatistics, "true");
            cfg.CurrentSessionContext<ThreadStaticSessionContext>();
            SchemaMetadataUpdater.QuoteTableAndColumns(cfg);
        }
    }
}