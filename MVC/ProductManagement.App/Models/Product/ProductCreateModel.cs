namespace ProductManagement.App.Models.Product
{
    public class ProductCreateModel
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public bool IsActice { get; set; }
    }
}
