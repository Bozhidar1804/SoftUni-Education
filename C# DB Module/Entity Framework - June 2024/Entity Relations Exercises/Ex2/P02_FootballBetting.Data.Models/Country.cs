﻿using P02_FootballBetting.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        public string Name { get; set; } = null!;

        // Set navigation collections
        public virtual ICollection<Town> Towns { get; set; }
    }
}
