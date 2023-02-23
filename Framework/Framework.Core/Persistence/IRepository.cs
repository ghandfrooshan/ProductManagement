using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Persistence
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IEntityBase, IAggregateRoot<TAggregateRoot>
    {
    }
}
