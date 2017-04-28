namespace TeamSL.Infrastructure.Domain.Queries
{
    public interface IQueryGateway
    {
        TResult Read<TResult>(IQuery<TResult> query);
    }
}