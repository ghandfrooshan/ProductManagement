using Framework.Application;
using Framework.Core.Application;
using Framework.Facade;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Facade.Contracts.Products;

namespace ProductManagement.ProductContext.Facade.Products
{
    public class ProductCommandfacade : FacadeCommandBase,IProductCommandfacade
    {

        public ProductCommandfacade(ICommandBus commandBus) : base(commandBus)
            
        {

        }
        void IProductCommandfacade.AddProductPrice(ProductPriceAddCommand command)
        {
            CommandBus.Dispatch(command);
        }

        void IProductCommandfacade.CreateProduct(ProductCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        void IProductCommandfacade.DeleteProduct(ProductDeleteCommand command)
        {
            CommandBus.Dispatch(command);
        }

        void IProductCommandfacade.RemoveProductPrice(ProductPriceEditCommand command)
        {
            CommandBus.Dispatch(command);
        }

        void IProductCommandfacade.SetActiveProduct(ProductSetActiveCommand command)
        {
            CommandBus.Dispatch(command);
        }

        void IProductCommandfacade.UpdateProduct(ProductUpdateCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}