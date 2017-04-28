namespace TeamSL.Infrastructure.Domain.Queries
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        TResult Ask(TQuery query);
    }
}
