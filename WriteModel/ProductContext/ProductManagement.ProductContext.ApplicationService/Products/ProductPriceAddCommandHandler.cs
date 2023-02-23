using Framework.Core.Persistence;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Domain.Products.Services;
using ProductManagement.ProductContext.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Application;
using ProductManagement.Constants;

namespace ProductManagement.ProductContext.ApplicationService.Products
{
    public class ProductPriceAddCommandHandler : ICommandHandler<ProductPriceAddCommand>
    {
        private readonly IEntityIdGenerator<ProductPrice> idGenerator;
        private readonly IProductRepository productRepository;

        public ProductPriceAddCommandHandler(IEntityIdGenerator<ProductPrice> idGenerator, IProductRepository productRepository)
        {
            this.idGenerator = idGenerator;
            this.productRepository = productRepository;
        }

        public void ExecuteAsync(ProductPriceAddCommand command)
        {

            var activeProductPrice = productRepository.GetActiveProductPrice(command.ProductId, command.Currency, command.FromDate);

            var newProductPrice = new ProductPrice(idGenerator, activeProductPrice.Price, command.Price, command.Currency, command.FromDate, command.ToDate ?? DomainParameter.MaxDate);


            if (activeProductPrice != null)
                activeProductPrice.ToDate = command.FromDate.AddDays(-1);

            productRepository.UpdateProductPrice(activeProductPrice);
            productRepository.CreateProductPrice(newProductPrice);

   

        }
   
    }
}
