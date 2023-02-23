using Framework.Application;
using Framework.AssemblyHelper;
using Framework.Core.Application;
using Framework.Core.DependencyInjection;
using Framework.Core.Domain;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Mapper;
using Framework.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductManagement.Persistence;
using ProductManagement.ReadModel.Queries.Contracts;
using ProductManagement.ReadModel.Queries.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.ReadModel.Context.Models;
using ProductManagement.ProductContext.Facade.Products;
using ProductManagement.ProductContext.Facade.Contracts.Products;
using ProductManagement.UserContext.Facade.Contract.Users;
using ProductManagement.UserContext.Facade.Users;

namespace Framework.DependencyInjection
{

    public abstract class RegistrarBase<TRegister> : IRegistrar
    {
        private readonly AssemblyHelper.AssemblyHelper assemblyHelper;
        public RegistrarBase()
        {
            var nameSpaceSpell = typeof(TRegister).Namespace.Split('.');
            var schemaName = nameSpaceSpell[0] + "." + nameSpaceSpell[1];
            assemblyHelper = new AssemblyHelper.AssemblyHelper(schemaName);
        }
        public virtual void Register(IServiceCollection services, string connectionString)
        {
            RegisterPersistence(services, connectionString);
            RegisterFramework(services);
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterCommandHandlers(services);
            RegisterFacade(services);
        }

        private void RegisterFacade(IServiceCollection services)
        {
            services.AddScoped<IProductQueryFacade, ProductQueryFacade>();
            services.AddScoped<IProductCommandfacade, ProductCommandfacade>();
            services.AddScoped<IUserCommandfacade, UserCommandfacade>();
        }

        private void RegisterPersistence(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IDbContext, ProductManagementDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<ProductManagementContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            
            services.TryAddScoped<SignInManager<IdentityUser>>();


        }

        private void RegisterFramework(IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper.Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDiContainer, DiContainer>();
            services.AddTransient(typeof(IEntityIdGenerator<>), typeof(EntityIdGenerator<>));
            services.AddScoped<ICommandBus, CommandBus>();
            
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            var repositories = assemblyHelper.GetTypes(typeof(RepositoryBase<>));
            foreach (var repository in repositories)
            {
                var baseInterfaces = repository.GetInterfaces().Where(a => a.IsGenericType == false);
                foreach (var baseInterface in baseInterfaces)
                    services.AddScoped(baseInterface, repository);
            }

        }

        private void RegisterServices(IServiceCollection services)
        {
            var domainServices = assemblyHelper.GetClassByInterface(typeof(IDomainService))
                .Where(a => a.IsInterface == false);

            foreach (var service in domainServices)
            {
                var baseInterface = service.GetInterfaces().Single(a => a.GetMembers().Any());
                services.AddTransient(baseInterface, service);
            }
        }



        private void RegisterCommandHandlers(IServiceCollection services)
        {
            var commandHandlers = assemblyHelper.GetClassByInterface(typeof(ICommandHandler<>));
            foreach (var commandHandler in commandHandlers)
            {
                var baseInterface = commandHandler.GetInterfaces()[0];
                services.AddScoped(baseInterface, commandHandler);
            }
        }

    }
}
