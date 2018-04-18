using System;
using System.Linq.Expressions;

namespace Specification.Core
{
    internal class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;

        internal ParameterReplacer(ParameterExpression parameter)
        {
            this._parameter = parameter ?? throw new ArgumentNullException();
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(this._parameter);
        }
    }
}