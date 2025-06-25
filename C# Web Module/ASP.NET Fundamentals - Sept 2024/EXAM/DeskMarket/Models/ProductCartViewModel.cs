namespace DeskMarket.Models
{
    public class ProductCartViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
