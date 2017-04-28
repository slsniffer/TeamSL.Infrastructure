namespace TeamSL.Infrastructure.Data.Specifications
{
    public interface ISpecification<in TRecord>
        where TRecord : Record
    {
        bool IsSatisfiedBy(TRecord record);
    }
}