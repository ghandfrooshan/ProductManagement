using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Mapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source);
        IList<TDestination> Map<TDestination, TSource>(IList<TSource> source);

    }
}
