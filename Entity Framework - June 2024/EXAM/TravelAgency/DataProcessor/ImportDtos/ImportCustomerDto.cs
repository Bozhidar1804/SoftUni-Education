using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [Required]
        [XmlAttribute("phoneNumber")]
        [MinLength(13)]
        [MaxLength(13)]
        [RegularExpression(@"^\+\d{12}$")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlElement("FullName")]
        [MinLength(4)]
        [MaxLength(60)]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement("Email")]
        [MinLength(6)]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
    }
}
