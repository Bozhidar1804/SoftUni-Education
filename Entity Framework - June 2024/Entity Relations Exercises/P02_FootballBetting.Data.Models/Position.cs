﻿using P02_FootballBetting.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PositionNameMaxLength)]
        public string Name { get; set; }
    }
}
