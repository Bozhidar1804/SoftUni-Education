using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boardgames.Data.DataConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [MinLength(SellerNameMinLength)]
        [MaxLength(SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(AddressNameMinLength)]
        [MaxLength(AddressNameMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(@"^www\.[a-zA-Z0-9-]+\.com$")]
        public string Website { get; set; } = null!;

        [Required]
        public int[] Boardgames { get; set; } = null!;
    }
}
