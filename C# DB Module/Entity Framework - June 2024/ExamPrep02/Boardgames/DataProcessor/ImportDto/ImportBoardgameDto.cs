﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using static Boardgames.Data.DataConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType(nameof(Boardgame))]
    public class ImportBoardgameDto
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(BoardgameNameMinLength)]
        [MaxLength(BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;


        [XmlElement(nameof(Rating))]
        [Required]
        [Range(BoardgameRatingMinValue, BoardgameRatingMaxValue)]
        public double Rating { get; set; }


        [XmlElement(nameof(YearPublished))]
        [Required]
        [Range(BoardGameYearPublishedMinValue, BoardGameYearPublishedMaxValue)]
        public int YearPublished { get; set; }


        [XmlElement(nameof(CategoryType))]
        [Required]
        public int CategoryType { get; set; }


        [XmlElement(nameof(Mechanics))]
        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
