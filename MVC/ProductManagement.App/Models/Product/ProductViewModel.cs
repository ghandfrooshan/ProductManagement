namespace ProductManagement.App.Models.Product
{
    public class ProductViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        public double Price_Usd { get; set; }
        public double Price_Eur { get; set; }
        public double Price_lira { get; set; }
    }
}
