using Framework.Core.Application;

namespace ProductManagement.ProductContext.ApplicationService.Contracts.Products
{
    public class ProductPriceRemoveCommand : Command
    {
        public long ProducPricetId { get; set; }

    }
}