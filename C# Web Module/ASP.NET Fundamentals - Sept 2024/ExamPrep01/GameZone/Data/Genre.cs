using System.ComponentModel.DataAnnotations;
using static GameZone.ApplicationConstants.EntityValidationConstants.Genre;

namespace GameZone.Data
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
