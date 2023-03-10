using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Persistence
{
    public interface IEntityIdGenerator<TEntity> where TEntity : class
    {
        long GetNewId();
    }
}
