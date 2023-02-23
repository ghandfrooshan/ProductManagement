using Microsoft.Extensions.DependencyInjection;
using ProductManagement.ReadModel.Queries.Contracts;
using ProductManagement.ReadModel.Queries.Facade;

namespace ProductManagement.ReadModel.Configuration
{
    public class Registrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IProductQueryFacade,ProductQueryFacade>();
           
        }
    }
}