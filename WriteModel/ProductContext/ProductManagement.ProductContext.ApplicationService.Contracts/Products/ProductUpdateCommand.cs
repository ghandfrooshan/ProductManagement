using Framework.Core.Application;

namespace ProductManagement.ProductContext.ApplicationService.Contracts.Products
{
    public class ProductUpdateCommand : Command
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        //public bool IsActice { get; set; }
        public int CategoryId { get; set; }
    }
}