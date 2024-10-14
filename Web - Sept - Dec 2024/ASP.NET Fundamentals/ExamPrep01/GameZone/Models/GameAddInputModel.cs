using GameZone.Data;
using MessagePack.Formatters;
using System.ComponentModel.DataAnnotations;
using static GameZone.ApplicationConstants.EntityValidationConstants.Game;

namespace GameZone.Models
{
    public class GameAddInputModel
    {
        [Required]
        [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength)]
        public string Title { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength)]
        public string Description { get; set; } = string.Empty!;

        [Required]
        public string ReleasedOn { get; set; } = DateTime.Today.ToString(GameReleasedOnFormat);

        [Required]
        public int GenreId { get; set; }

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
    }
}
