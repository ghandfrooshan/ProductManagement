using System.ComponentModel.DataAnnotations;

namespace ProductManagement.ReadModel.Queries.Contracts.DataContract
{
  

    public class ProductDto
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public long ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
   
     
    }
}
