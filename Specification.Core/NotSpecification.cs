using System;
using System.Linq;
using System.Linq.Expressions;

namespace Specification.Core
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification)
        {
            this._specification = specification ?? throw new NullReferenceException();
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = this._specification.ToExpression();

            var notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}