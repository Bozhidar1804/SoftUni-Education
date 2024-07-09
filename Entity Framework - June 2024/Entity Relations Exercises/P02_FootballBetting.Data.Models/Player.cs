using P02_FootballBetting.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayerNameMaxLength)]
        public string Name { get; set; }
        public int SquadNumber { get; set; }

        // SQL Type -> BIT
        // By default bull is NOT NULL, REQUIRED
        public bool IsInjured { get; set; }

        public int PositionId { get; set; }

        // This FK should not be NOT NULL
        // This may cause a problem in Judge!!!
        public int? TeamId { get; set; }
        public int TownId { get; set; }

    }
}
