using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data
{
    public class GamerGame
    {
        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; } = null!;

        [Required]
        public string GamerId { get; set; } = null!;

        [ForeignKey(nameof(GamerId))]
        public virtual IdentityUser Gamer { get; set; } = null!;
    }
}
