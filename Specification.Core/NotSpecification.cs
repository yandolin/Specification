using System;
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
            throw new NotImplementedException();
        }
    }
}