using Framework.Core.Application;

namespace ProductManagement.ProductContext.ApplicationService.Contracts.Products
{
    public class ProductPriceAddCommand : Command
    {
        public long ProductId { get; set; }
        public float Price { get; set; }
        public int Currency { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsActive { get; set; }
    }
}