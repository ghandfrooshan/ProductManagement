using Framework.Core.Application;

namespace ProductManagement.ProductContext.ApplicationService.Contracts.Products
{
    public class ProductDeleteCommand : Command
    {
        public long ProductId { get; set; }

    }
}