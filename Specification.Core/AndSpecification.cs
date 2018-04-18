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
            this._leftSpecification = leftSpecification ?? throw new ArgumentNullException();
            this._rightSpecification = rightSpecification ?? throw new ArgumentNullException();
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = this._leftSpecification.ToExpression();
            var rightExpression = this._rightSpecification.ToExpression();

            var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

            var parameter = leftExpression.Parameters.Single();

            andExpression = (BinaryExpression) new ParameterReplacer(parameter).Visit(andExpression);

            return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
        }
    }
}