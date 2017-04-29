using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace TeamSL.Infrastructure.Example
{
    public interface IDbCreator
    {
        void Create();
    }

    public class DbCreator : IDbCreator
    {
        private readonly IDbConfiguration _dbConfiguration;

        public DbCreator(IDbConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

        public void Create()
        {
            try
            {
                var persister = SQLiteConfiguration
                    .Standard
                    .UsingFile(_dbConfiguration.DatabaseName);

                var configuration = Fluently
                    .Configure()
                    .Database(persister)
                    .Mappings(map => map.FluentMappings.AddFromAssembly(GetType().Assembly))
                    .BuildConfiguration();

                new SchemaExport(configuration).Execute(false, true, false);
            }
            catch
            {
                //ignore
            }
        }
    }
}