using DeskMarket.Data.Models;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.ApplicationConstants.EntityValidationConstants.Product;

namespace DeskMarket.Models
{
    public class ProductAddInputModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(ProductPriceMinValue, ProductPriceMaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string AddedOn { get; set; } = DateTime.Today.ToString(DateAddedOnFormat);

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CategoryId { get; set; }

        public List<Category> Categories = new List<Category>();
    }
}
