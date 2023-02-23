using Framework.Domain;
using ProductManagement.ProductContext.Domain.Products;
using System;
namespace ProductManagement.ProductContext.Domain.Products
{
    public class ProductProperty : EntityBase<ProductProperty>
    {
        public long ProductId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsActive { get; set; }
        public Product product { get; set; }
        public Property Property { get; set; }

    }
}
