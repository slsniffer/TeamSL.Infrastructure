using System;
using System.Linq.Expressions;

namespace TeamSL.Infrastructure.Data.Specifications
{
    public abstract class ExpressionQuerySpecification<T> : QuerySpecification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        protected ExpressionQuerySpecification(Expression<Func<T, bool>> expression)
        {
            _expression = expression;
        }

        protected override Expression<Func<T, bool>> MatchingCriteria()
        {
            return _expression;
        }
    }
}