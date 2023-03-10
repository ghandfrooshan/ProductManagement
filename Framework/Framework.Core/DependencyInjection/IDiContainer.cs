using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.DependencyInjection
{
    public interface IDiContainer
    {
        T Resolve<T>();

        object Resolve(Type type);
    }
}
