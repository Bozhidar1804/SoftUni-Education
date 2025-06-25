namespace Medicines.DataProcessor.ImportDtos
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static Medicines.Data.DataConstraints;
    [XmlType(nameof(Medicine))]
    public class ImportMedicineDto
    {
        [XmlAttribute("category")]
        [Range(MedicineCategoryMinValue, MedicineCategoryMaxValue)]
        public int Category { get; set; }

        [XmlElement("Name")]
        [Required]
        [MinLength(MedicineNameMinLength)]
        [MaxLength(MedicineNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Price")]
        [Range(MedicinePriceMinValue, MedicinePriceMaxValue)]
        public double Price { get; set; }

        [XmlElement("ProductionDate")]
        [Required]
        public string ProductionDate { get; set; } = null!;

        [XmlElement("ExpiryDate")]
        [Required]
        public string ExpiryDate { get; set; } = null!;

        [XmlElement("Producer")]
        [Required]
        [MinLength(ProducerMinLength)]
        [MaxLength(ProducerMaxLength)]
        public string Producer { get; set; } = null!;
    }
}
