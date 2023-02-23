using Framework.Core.Domain;
using Framework.Core.Persistence;
using Framework.Domain;
using ProductManagement.ProductContext.Domain.Products.Exceptions;
using System.Linq.Expressions;

namespace ProductManagement.ProductContext.Domain.Products
{
    public class Product : EntityBase<Product>, IAggregateRoot<Product>
    {

        public Product()
        {

        }

        public Product(IEntityIdGenerator<Product> idGenerator, string name, int categoryId,bool isActive) : base(idGenerator)
        {
                Name= name;
            CategoryId= categoryId;
            IsActice = isActive;
            SetId();
        }
        public string Name { get; set; }
        public bool IsActice { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        public IList<ProductPrice> ProductPriceList { get; set; }
        public IList<ProductProperty> ProductPropertyList { get; set; }


        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ProductNameIsRequiredException();
            else
                Name = name;
        }
        public IEnumerable<Expression<Func<Product, object>>> GetAggregateExpressions()
        {
            yield return a => a.ProductPriceList;
            yield return a => a.ProductPropertyList;
        }

       
    }
}