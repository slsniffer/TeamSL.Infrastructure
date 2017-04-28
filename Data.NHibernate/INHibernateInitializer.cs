using NHibernate.Cfg;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public interface INHibernateInitializer
    {
        Configuration GetConfiguration();
    }
}