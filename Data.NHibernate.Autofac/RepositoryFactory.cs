using Autofac;

namespace TeamSL.Infrastructure.Data.NHibernate.Autofac
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IComponentContext _context;

        public RepositoryFactory(IComponentContext context)
        {
            _context = context;
        }

        public IReadRepository<TRecord> Read<TRecord>() where TRecord : Record
        {
            return _context.Resolve<IReadRepository<TRecord>>();
        }

        public IRepository<TRecord> Write<TRecord>() where TRecord : Record
        {
            return _context.Resolve<IRepository<TRecord>>();
        }
    }
}