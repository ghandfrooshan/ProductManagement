using Framework.Core.Application;
using Framework.Core.Persistence;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Domain.Products.Services;
using ProductManagement.ProductContext.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ProductContext.ApplicationService.Products
{
    public class ProductSetActiveCommandHandler : ICommandHandler<ProductSetActiveCommand>
    {
      
        private readonly IProductRepository productRepository;

        public ProductSetActiveCommandHandler(IProductRepository productRepository)
        {
          
            this.productRepository = productRepository;
        }

        public void ExecuteAsync(ProductSetActiveCommand command)
        {

            var product = productRepository.GetProductById(command.ProductId);
            
            product.IsActice = command.IsActice;


            productRepository.UpdateProduct(product);

        }
    
    }
}
