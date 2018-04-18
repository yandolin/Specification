using System;
using System.Linq;
using System.Linq.Expressions;

namespace Specification.Core
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            this._leftSpecification = leftSpecification ?? throw new ArgumentNullException();
            this._rightSpecification = rightSpecification ?? throw new ArgumentNullException();
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = this._leftSpecification.ToExpression();
            var rightExpression = this._rightSpecification.ToExpression();

            var orExpression = Expression.Or(leftExpression.Body, rightExpression.Body);

            var parameter = leftExpression.Parameters.Single();

            orExpression = (BinaryExpression) new ParameterReplacer(parameter).Visit(orExpression);

            return Expression.Lambda<Func<T, bool>>(orExpression, parameter);
        }
    }
}