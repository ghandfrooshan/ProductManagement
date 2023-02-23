using Framework.Core.Application;

namespace ProductManagement.ProductContext.ApplicationService.Contracts.Products
{
    public class ProductCreateCommand:Command 
    {
        public string ProductName { get; set; }
        public bool IsActice { get; set; }
        public int CategoryId { get; set; }
    }
}