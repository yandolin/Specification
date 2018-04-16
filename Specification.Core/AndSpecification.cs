using System;
using System.Linq;
using System.Linq.Expressions;

namespace Specification.Core
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            this._leftSpecification = leftSpecification ?? throw new NullReferenceException();
            this._rightSpecification = rightSpecification ?? throw new NullReferenceException();
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = this._leftSpecification.ToExpression();
            var rightExpression = this._rightSpecification.ToExpression();

            var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }
}