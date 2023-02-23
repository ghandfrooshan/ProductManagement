using Framework.Core.Application;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Domain.Products.Services;

namespace ProductManagement.ProductContext.ApplicationService.Products
{
    public class ProductUpdateCommandHandler : ICommandHandler<ProductUpdateCommand>
    {

        private readonly IProductRepository productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {

            this.productRepository = productRepository;
        }

        public void ExecuteAsync(ProductUpdateCommand command)
        {

           var product= productRepository.GetProductById(command.ProductId);
            product.SetName(command.Name);
            product.CategoryId= command.CategoryId; 
           

            productRepository.UpdateProduct(product);

        }

    }
}