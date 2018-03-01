using Autofac;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Domain
{
    public class AutofacQueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IComponentContext _context;

        public AutofacQueryHandlerFactory(IComponentContext context)
        {
            _context = context;
        }

        public IQueryHandler<TQuery, TResult> Create<TQuery, TResult>()
            where TQuery : class, IQuery<TResult>
            where TResult : class
        {
            return _context.Resolve<IQueryHandler<TQuery, TResult>>();
        }
    }
}
