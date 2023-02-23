using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ReadModel.Queries.Contracts.DataContract
{
    public class ProductWithPriceDto
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public long ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Price Usd")]
        public double? Price_Usd { get; set; }
        [Display(Name = "Price Eur")]
        public double? Price_Eur { get; set; }
        [Display(Name = "Price lira")]
        public double? Price_lira { get; set; }
    }
}
