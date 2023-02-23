using Framework.Core.Mapper;
using Framework.Facade;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Constants;
using ProductManagement.ReadModel.Context.Models;
using ProductManagement.ReadModel.Queries.Contracts;
using ProductManagement.ReadModel.Queries.Contracts.DataContract;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ProductManagement.ReadModel.Queries.Facade
{


    public class ProductQueryFacade : FacadeQueryBase, IProductQueryFacade
    {
        private readonly ProductManagementContext db;
        private readonly IMapper mapper;

        public ProductQueryFacade(ProductManagementContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IList<ProductPriceDto> GetAllPriceByProductId()
        {
            throw new NotImplementedException();
        }
        public IList<ProductWithPriceDto> GetAllProduct()
        {

            List<ViewProductPrice> productsPrice = GetProductPrice(DateTime.Now);

            var products = productsPrice

                   .Join(db.Products,
                         //.Include(x => x.Category),
                         price => price.ProductId,
                         product => product.Id,
                         (price, product) => new ProductWithPriceDto
                         {
                             ProductId = product.Id,
                             ProductName = product.Name,
                             IsActive = product.IsActice,
                             CategoryId = product.CategoryId,
                             CategoryName = db.ProductCategories.Single(x => x.Id == product.CategoryId).Name,
                             Price_Usd = price.USD ?? 0.0,
                             Price_Eur = price.EUR ?? 0.0,
                             Price_lira = price.LIRA ?? 0.0
                         }).ToList();

            return products;
        }


        public IList<CategoryDto> GetCategories()
        {
            var res = db.ProductCategories.ToList();
            return mapper.Map<CategoryDto, ProductCategory>(res);
        }

        public ProductPriceDto GetProducPricetById(long id)
        {
            throw new NotImplementedException();
        }

   

        public ProductDto GetProductById(long id)
        {
            var product = db.Products
                .Include(x => x.Category)
                .Where(x => x.Id == id);

            var result = product
               .Select(x => new ProductDto
               {
                   CategoryId = x.CategoryId,
                   CategoryName = x.Category.Name,
                   ProductId = x.Id,
                   ProductName = x.Name
               }).Single();
                
            return result;

           
               
        }

        public IList<ProductWithPriceDto> GetProductsByCategoryId(int categoryId)
        {

            List<ViewProductPrice> productsPrice = GetProductPrice(DateTime.Now);
            var categories = db.ProductCategories;

            var products = productsPrice

                   .Join(db.Products.Where(x=>x.CategoryId==categoryId),
                         //.Include(x => x.Category),
                         price => price.ProductId,
                         product => product.Id,
                         (price, product) => new ProductWithPriceDto
                         {
                             ProductId = product.Id,
                             ProductName = product.Name,
                             IsActive = product.IsActice,
                             CategoryId = product.CategoryId,
                             CategoryName = db.ProductCategories.Single(x => x.Id == product.CategoryId).Name,
                             Price_Usd = price.USD ?? 0.0,
                             Price_Eur = price.EUR ?? 0.0,
                             Price_lira = price.LIRA ?? 0.0
                         }).ToList();

            return products;

        }


        private List<ViewProductPrice> GetProductPrice(DateTime date)
        {
            var dateParam = new SqlParameter("@date", date);
            var productsPrice = db
              .ProductPriceDtos
              .FromSqlRaw("exec usp_GetProductPriceByDate @date", dateParam).ToList();
            return productsPrice;
        }
    }
}