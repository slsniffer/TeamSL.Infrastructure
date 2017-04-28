using System;

namespace TeamSL.Infrastructure.Data.Specifications
{
    internal class NotSpecification<TRecord> : ISpecification<TRecord>
        where TRecord : Record
    {
        private readonly ISpecification<TRecord> _wrapped;

        protected ISpecification<TRecord> Wrapped
        {
            get
            {
                return _wrapped;
            }
        }

        internal NotSpecification(ISpecification<TRecord> spec)
        {
            if (spec == null)
            {
                throw new ArgumentNullException("spec");
            }

            _wrapped = spec;
        }

        public bool IsSatisfiedBy(TRecord candidate)
        {
            return !Wrapped.IsSatisfiedBy(candidate);
        }
    }
}