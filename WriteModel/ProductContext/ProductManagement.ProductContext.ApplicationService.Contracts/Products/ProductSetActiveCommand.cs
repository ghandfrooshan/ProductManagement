using Framework.Core.Application;

namespace ProductManagement.ProductContext.ApplicationService.Contracts.Products
{
    public class ProductSetActiveCommand : Command
    {
        public long ProductId { get; set; }
        public bool IsActice { get; set; }
    }
}