using System;
using System.Linq.Expressions;

namespace Specification.Core
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not(ISpecification<T> specification);
    }
}