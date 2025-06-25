using DeskMarket.Data.Models;

namespace DeskMarket.Models
{
    public class ProductEditViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string AddedOn { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public string SellerId { get; set; } = string.Empty;
    }
}
