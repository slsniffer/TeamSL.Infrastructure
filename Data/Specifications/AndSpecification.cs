using System;
using System.Diagnostics.Contracts;

namespace TeamSL.Infrastructure.Data.Specifications
{
    internal class AndSpecification<TRecord> : ISpecification<TRecord>
        where TRecord : Record
    {
        private readonly ISpecification<TRecord> _left;
        private readonly ISpecification<TRecord> _right;

        protected ISpecification<TRecord> Left
        {
            get
            {
                return _left;
            }
        }

        protected ISpecification<TRecord> Right
        {
            get
            {
                return _right;
            }
        }

        internal AndSpecification(ISpecification<TRecord> left, ISpecification<TRecord> right)
        {
            Contract.Requires<ArgumentNullException>(left != null);
            Contract.Requires<ArgumentNullException>(right != null);

            _left = left;
            _right = right;
        }

        public bool IsSatisfiedBy(TRecord candidate)
        {
            return Left.IsSatisfiedBy(candidate) && Right.IsSatisfiedBy(candidate);
        }
    }
}