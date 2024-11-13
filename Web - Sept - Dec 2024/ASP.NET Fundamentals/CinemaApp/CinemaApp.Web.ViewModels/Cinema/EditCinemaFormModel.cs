using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.Cinema;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class EditCinemaFormModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(LocationMaxLength)]
        [MinLength(LocationMinLength)]
        public string Location { get; set; } = null!;
    }
}
