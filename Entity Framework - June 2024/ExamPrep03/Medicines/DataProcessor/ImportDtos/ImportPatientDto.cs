using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicines.Data.DataConstraints;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientDto
    {
        [JsonProperty(nameof(FullName))]
        [Required]
        [MinLength(PatientFullNameMinLength)]
        [MaxLength(PatientFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [JsonProperty(nameof(AgeGroup))]
        [Required]
        [Range(PatientAgeGroupMinValue, PatientAgeGroupMaxValue)]
        public int AgeGroup { get; set; }

        [JsonProperty(nameof(Gender))]
        [Required]
        [Range(PatientGenderMinValue, PatientGenderMaxValue)]
        public int Gender { get; set; }

        [JsonProperty(nameof(Medicines))]
        [Required]
        public int[] Medicines { get; set; } = null!;
    }
}
