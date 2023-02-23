using Framework.Core.Application;
using Framework.Core.Persistence;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Domain.Products.Services;
using ProductManagement.ProductContext.Domain.Products;

namespace ProductManagement.ProductContext.ApplicationService.Products
{
    public class ProductDeleteCommandHandler : ICommandHandler<ProductDeleteCommand>
    {

        private readonly IProductRepository productRepository;

        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {

            this.productRepository = productRepository;
        }

        public void ExecuteAsync(ProductDeleteCommand command)
        {


            productRepository.DeleteProduct(command.ProductId);

        }
    }
}