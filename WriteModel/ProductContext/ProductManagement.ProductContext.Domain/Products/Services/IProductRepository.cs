using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ProductContext.Domain.Products.Services
{
    public interface IProductRepository : IRepository<Product>
    {
        void CreateProduct(Product product);
        void DeleteProduct(long productId);
        Product GetProductById(long productId);
        void UpdateProduct(Product product);


        ProductPrice GetActiveProductPrice(long productId, int currency, DateTime date);
        void UpdateProductPrice(ProductPrice? productPrice);
        void CreateProductPrice(ProductPrice ProductPrice);
        ProductPrice GetProductPriceById(long producPricetId);
        void DeleteProductPrice(long producPricetId);
    }
}
