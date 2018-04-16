using System;
using System.Linq.Expressions;

namespace Specification.Core
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Not(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }
    }
}