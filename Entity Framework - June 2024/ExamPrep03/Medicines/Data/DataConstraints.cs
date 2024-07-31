using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data
{
    public class DataConstraints
    {
        // Pharmacy
        public const byte PharmacyNameMinLength = 2;
        public const byte PharmacyNameMaxLength = 50;
        public const byte PharmacyPhoneNumberLength = 14;
        public const string PharmacyBooleanRegex = @"^(true|false)$";

        // Category
        public const byte MedicineCategoryMinValue = 0;
        public const byte MedicineCategoryMaxValue = 4;

        // Medicine
        public const byte MedicineNameMinLength = 3;
        public const byte MedicineNameMaxLength = 150;
        public const double MedicinePriceMinValue = 0.01;
        public const double MedicinePriceMaxValue = 1000.00;
        public const byte ProducerMinLength = 3;
        public const byte ProducerMaxLength = 100;

        // Patient
        public const byte PatientFullNameMinLength = 5;
        public const byte PatientFullNameMaxLength = 100;
        public const byte PatientAgeGroupMinValue = 0;
        public const byte PatientAgeGroupMaxValue = 2;
        public const byte PatientGenderMinValue = 0;
        public const byte PatientGenderMaxValue = 1;
    }
}
