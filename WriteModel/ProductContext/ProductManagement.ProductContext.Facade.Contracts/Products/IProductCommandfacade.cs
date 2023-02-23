using ProductManagement.ProductContext.ApplicationService.Contracts.Products;

namespace ProductManagement.ProductContext.Facade.Contracts.Products
{
    public interface IProductCommandfacade
    {
        void CreateProduct(ProductCreateCommand command);
        void DeleteProduct(ProductDeleteCommand command);
        void AddProductPrice(ProductPriceAddCommand command);
        void RemoveProductPrice(ProductPriceEditCommand command);
        void SetActiveProduct(ProductSetActiveCommand command);
        void UpdateProduct(ProductUpdateCommand command);
    }
}