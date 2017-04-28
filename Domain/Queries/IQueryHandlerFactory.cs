namespace TeamSL.Infrastructure.Domain.Queries
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery, TResult> Create<TQuery, TResult>()
            where TQuery : class, IQuery<TResult>
            where TResult : class;
    }
}
