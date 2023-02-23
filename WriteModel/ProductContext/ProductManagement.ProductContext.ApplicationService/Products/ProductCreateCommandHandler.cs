using Framework.Core.Application;
using Framework.Core.Persistence;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Domain.Products;
using ProductManagement.ProductContext.Domain.Products.Services;
using System.Reflection.Emit;

namespace ProductManagement.ProductContext.ApplicationService.Products
{
    public class ProductCreateCommandHandler : ICommandHandler<ProductCreateCommand>
    {
        private readonly IEntityIdGenerator<Product> idGenerator;
        private readonly IProductRepository productRepository;

        public ProductCreateCommandHandler(IEntityIdGenerator<Product> idGenerator, IProductRepository productRepository)
        {
            this.idGenerator = idGenerator;
            this.productRepository = productRepository;
        }

        public void ExecuteAsync(ProductCreateCommand command)
        {

            var product = new Product(idGenerator, command.ProductName, command.CategoryId,command.IsActice);
            productRepository.CreateProduct(product);
            
        }
    }
}