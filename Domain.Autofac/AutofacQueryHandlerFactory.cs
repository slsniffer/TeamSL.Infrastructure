using Autofac;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Domain.Autofac
{
    public class AutofacQueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IComponentContext _resolver;

        public AutofacQueryHandlerFactory(IComponentContext resolver)
        {
            _resolver = resolver;
        }

        public IQueryHandler<TQuery, TResult> Create<TQuery, TResult>()
            where TQuery : class, IQuery<TResult>
            where TResult : class
        {
            return _resolver.Resolve<IQueryHandler<TQuery, TResult>>();
        }
    }
}
