using System.ComponentModel.DataAnnotations;

using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key] // Sets PK of the table --> UNIQUE, NOT NULL
        public int TeamId { get; set; }

        [Required] // NOT NULL constraint in SQL
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.TeamLogoUrlMaxLength)]
        public string LogoUrl { get; set; }

        [MaxLength(ValidationConstants.TeamInitialsMaxLength)]
        public string Initials { get; set; }

        //REQUIRED (NOT NULL) by default because decimal data type is not nullable
        public decimal Budget { get; set; }

        // TODO: Entity relations
        public int PrimaryKitColorId { get; set; }
        public int SecondaryKitColorId { get; set; }
        public int TownId { get; set; }
    }
}