namespace TeamSL.Infrastructure.Data.Specifications
{
    public static class SpecificationExtensions
    {
        public static ISpecification<TRecord> And<TRecord>(this ISpecification<TRecord> left, ISpecification<TRecord> right)
            where TRecord : Record
        {
            return new AndSpecification<TRecord>(left, right);
        }

        public static ISpecification<TRecord> Or<TRecord>(this ISpecification<TRecord> left, ISpecification<TRecord> right)
            where TRecord : Record
        {
            return new OrSpecification<TRecord>(left, right);
        }

        public static ISpecification<TRecord> Not<TRecord>(this ISpecification<TRecord> spec)
            where TRecord : Record
        {
            return new NotSpecification<TRecord>(spec);
        }
    }
}