namespace DeskMarket.Models
{
    public class ProductDeleteViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Seller { get; set; } = string.Empty;
        public string SellerId { get; set; } = string.Empty;
    }
}
