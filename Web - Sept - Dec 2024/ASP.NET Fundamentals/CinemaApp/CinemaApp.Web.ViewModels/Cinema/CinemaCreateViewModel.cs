namespace CinemaApp.Web.ViewModels.Cinema
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Services.Mapping;

    using static CinemaApp.Common.EntityValidationConstants.Cinema;
    public class CinemaCreateViewModel : IMapTo<Cinema>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(LocationMinLength)]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;
    }
}
