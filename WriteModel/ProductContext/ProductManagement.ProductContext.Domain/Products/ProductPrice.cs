using Framework.Core.Persistence;
using Framework.Domain;
using ProductManagement.ProductContext.Domain.Products;
using ProductManagement.ProductContext.Domain.Products.Exceptions;
using System;
using System.Data;
using System.Xml.Linq;


namespace ProductManagement.ProductContext.Domain.Products
{
    public class ProductPrice : EntityBase<ProductPrice>
    {

        public ProductPrice()
        {

        }

        public ProductPrice(IEntityIdGenerator<ProductPrice> idGenerator, float? CurrentPrice, float newPrice, int currency, DateTime fromDate, DateTime toDate) : base(idGenerator)
        {

            SetPrice(CurrentPrice, newPrice);
            CurrencyId = currency;
            SetDate(fromDate, toDate);
            SetId();
        }



        public long ProductId { get; set; }
        public float Price { get; set; }
        public int CurrencyId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Currency Currency { get; set; }
        public Product product { get; set; }


        public void SetPrice(float? currentPrice, float newPrice)
        {

            if (currentPrice.HasValue && currentPrice == newPrice)
                throw new currentAndNewPriceAreTheSameException();
            if (newPrice <= 0.0)
                throw new ProductPriceMustBeGreaterThanZeroException();
            else
                Price = newPrice;
        }
        private void SetDate(DateTime fromDate, DateTime toDate)
        {

            if (fromDate > toDate)
                throw new FromDateCanNotBeGreaterThanToDateException();
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}