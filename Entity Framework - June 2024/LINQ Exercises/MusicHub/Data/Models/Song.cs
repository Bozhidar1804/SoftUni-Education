using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationConstants.SongNameMaxLength)]

        // In EF <= 3.1.x we use [Required] attribute
        // In EF >= 6.x everything is required and we add "?" to be nullable
        public string Name { get; set; } = null!;

        // TimeSpan datatype is required by default
        // In the DB this will be stored as BIGINT <=> Ticks Count
        public TimeSpan Duration { get; set; }

        // Modified in OnModelCreating!!!
        public DateTime CreatedOn { get; set; }
        public Genre Genre { get; set; }

        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }
        public virtual Album? Album { get; set; }

        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; } = null!;

        public decimal Price { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }

    }
}
