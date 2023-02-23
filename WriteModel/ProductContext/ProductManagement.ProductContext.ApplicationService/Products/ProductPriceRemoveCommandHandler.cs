using Framework.Core.Application;
using Framework.Core.Persistence;
using ProductManagement.Constants;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Domain.Products.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ProductContext.ApplicationService.Products
{
    public class ProductPriceRemoveCommandHandler : ICommandHandler<ProductPriceRemoveCommand>
    {
      
        private readonly IProductRepository productRepository;

        public ProductPriceRemoveCommandHandler( IProductRepository productRepository)
        {
            
            this.productRepository = productRepository;
        }

        public void ExecuteAsync(ProductPriceRemoveCommand command)
        {

            var ProductPrice = productRepository.GetProductPriceById(command.ProducPricetId);
            var activeProductPrice = productRepository.GetActiveProductPrice(ProductPrice.ProductId, ProductPrice.CurrencyId, ProductPrice.FromDate);

            if (activeProductPrice != null)
                activeProductPrice.ToDate = DomainParameter.MaxDate;

            productRepository.UpdateProductPrice(activeProductPrice);
            productRepository.DeleteProductPrice(command.ProducPricetId);



        }
    }
}
