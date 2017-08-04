namespace TeamSL.Infrastructure.Domain.Queries
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Ask(TQuery query);
    }
}
