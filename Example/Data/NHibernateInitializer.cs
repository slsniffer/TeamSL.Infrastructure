using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using TeamSL.Infrastructure.Data.NHibernate;

namespace TeamSL.Infrastructure.Example.Data
{
    public class NHibernateInitializer : INHibernateInitializer
    {
        private readonly IDbConfiguration _dbConfiguration;

        public NHibernateInitializer(IDbConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

        public Configuration GetConfiguration()
        {
            var config = SQLiteConfiguration.Standard.UsingFile(_dbConfiguration.DatabaseName);

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