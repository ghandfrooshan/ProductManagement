using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DependencyInjection
{
    public interface IRegistrar
    {
        void Register(IServiceCollection services, string connectionString);
    }
}
