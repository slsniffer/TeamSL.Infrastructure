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
        public void Create()
        {
            try
            {
                var persister = SQLiteConfiguration
                    .Standard
                    .UsingFile("test.db");

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