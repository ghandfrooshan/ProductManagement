using Framework.Persistence;
using ProductManagement.ProductContext.Domain.Products;
using ProductManagement.ProductContext.Domain.Products.Services;

namespace ProductManagement.ProductContext.Infrastructure.Persistence.Products
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void CreateProductPrice(ProductPrice ProductPrice)
        {
            DbContext.Set<ProductPrice>().Add(ProductPrice);
        }

        public void DeleteProduct(long productId)
        {
          Delete(GetProductById(productId));
        }

        public void DeleteProductPrice(long producPricetId)
        {
            DbContext.Set<ProductPrice>().Remove(GetProductPriceById(producPricetId));
        }

        public ProductPrice GetActiveProductPrice(long productId, int currency, DateTime date)
        {
            return DbContext.Set<ProductPrice>().Single(x => x.ProductId == productId && x.CurrencyId==currency&& date>=x.FromDate && date<=x.ToDate );
        }

        public Product GetProductById(long productId)
        {
            return Set.Single(a => a.Id == productId);
        }

        public ProductPrice GetProductPriceById(long producPricetId)
        {
            return DbContext.Set<ProductPrice>().Single(x => x.Id == producPricetId);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }

        public void UpdateProductPrice(ProductPrice? productPrice)
        {
             DbContext.Set<ProductPrice>().Update(productPrice);
        }
    }
}