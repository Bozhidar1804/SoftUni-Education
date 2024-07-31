using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Medicines.Data.DataConstraints;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Pharmacy))]
    public class ImportPharmacyDto
    {
        [Required]
        [XmlAttribute("non-stop")]
        [RegularExpression(PharmacyBooleanRegex)]
        public string IsNonStop { get; set; } = null!;

        [XmlElement(nameof(Name))]
        [MinLength(PharmacyNameMinLength)]
        [MaxLength(PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement(nameof(PhoneNumber))]
        [MinLength(PharmacyPhoneNumberLength)]
        [MaxLength(PharmacyPhoneNumberLength)]
        [RegularExpression(@"\(\d{3}\) \d{3}-\d{4}")]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray(nameof(Medicines))]
        public ImportMedicineDto[] Medicines { get; set; } = null!;
    }
}
