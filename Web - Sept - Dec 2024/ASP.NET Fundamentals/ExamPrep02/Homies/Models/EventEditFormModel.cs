using System.ComponentModel.DataAnnotations;
using static Homies.ApplicationConstants.EntityValidationConstants.Event;


namespace Homies.Models
{
    public class EventEditFormModel
    {
        [Required]
        [MaxLength(EventNameMaxLength)]
        [MinLength(EventNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        [MinLength(EventDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Start { get; set; } = DateTime.Today.ToString(EventStartFormat);

        [Required]
        public string End { get; set; } = DateTime.Today.ToString(EventEndFormat);

        [Required]
        public int TypeId { get; set; }

        public ICollection<Data.Type> Types { get; set; } = new List<Data.Type>();
    }
}
