
using ProductManagement.ReadModel.Context.Models;
using ProductManagement.ReadModel.Queries.Contracts.DataContract;

namespace ProductManagement.ReadModel.Queries.Contracts
{
    public interface IProductQueryFacade
    {
        IList<ProductWithPriceDto> GetAllProduct();
        IList<ProductPriceDto> GetAllPriceByProductId();
        ProductDto GetProductById(long id);
        ProductPriceDto GetProducPricetById(long id);
        IList<CategoryDto> GetCategories();
        IList<ProductWithPriceDto> GetProductsByCategoryId(int categoryId);

    }
}