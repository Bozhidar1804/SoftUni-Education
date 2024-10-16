using System.ComponentModel.DataAnnotations;
using static Homies.ApplicationConstants.EntityValidationConstants.Type;

namespace Homies.Data
{
    public class Type
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
