using System;
using System.Linq.Expressions;

namespace Specification.Core
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            this._leftSpecification = leftSpecification ?? throw new NullReferenceException();
            this._rightSpecification = rightSpecification ?? throw new NullReferenceException();
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            throw new NotImplementedException();
        }
    }
}