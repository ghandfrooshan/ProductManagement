using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Domain
{
    public interface IAggregateRoot<TAggregateRoot> where TAggregateRoot : class, IEntityBase
    {
        IEnumerable<Expression<Func<TAggregateRoot, object>>> GetAggregateExpressions();
    }
}
