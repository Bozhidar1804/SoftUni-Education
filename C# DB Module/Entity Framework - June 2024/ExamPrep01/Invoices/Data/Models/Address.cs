using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    using static DataConstraints;
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StreetNameMaxLength)]
        public string StreetName { get; set; } = null!;

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public string PostCode { get; set; } = null!; // NVARCHAR(MAX)

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string City { get; set; } = null!; // NVARCHAR(15)

        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string Country { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;

    }
}
