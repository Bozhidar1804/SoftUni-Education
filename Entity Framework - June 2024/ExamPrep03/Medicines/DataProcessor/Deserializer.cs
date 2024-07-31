namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Utilities;
    using System.ComponentModel.DataAnnotations;
    using Medicines.DataProcessor.ImportDtos;
    using System.Text;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using System.Globalization;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPatientDto[] patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            ICollection<Patient> patientsToImport = new List<Patient>();

            foreach (ImportPatientDto dto in patientDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient newPatient = new Patient()
                {
                    FullName = dto.FullName,
                    AgeGroup = (AgeGroup)dto.AgeGroup,
                    Gender = (Gender)dto.Gender
                };

                foreach (int id in dto.Medicines)
                {
                    if (newPatient.PatientsMedicines.Any(pm => pm.MedicineId == id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = newPatient,
                        MedicineId = id
                    };

                    newPatient.PatientsMedicines.Add(patientMedicine);
                }

                patientsToImport.Add(newPatient);
                sb.AppendLine(String.Format(SuccessfullyImportedPatient, dto.FullName, newPatient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(patientsToImport);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Pharmacies";

            ImportPharmacyDto[] pharmacyDtos = xmlHelper.Deserialize<ImportPharmacyDto[]>(xmlString, xmlRoot);

            ICollection<Pharmacy> pharmaciesToImport = new List<Pharmacy>();

            foreach (ImportPharmacyDto dto in pharmacyDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy newPharmacy = new Pharmacy()
                {
                    IsNonStop = bool.Parse(dto.IsNonStop),
                    Name = dto.Name,
                    PhoneNumber = dto.PhoneNumber
                };

                foreach (ImportMedicineDto medicineDto in dto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineProductionDate;
                    bool isProductionDateValid = DateTime
                            .TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out medicineProductionDate);

                    if (!isProductionDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineExpiryDate;
                    bool isExpiryDateValid = DateTime
                        .TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out medicineExpiryDate);

                    if (!isExpiryDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (medicineProductionDate >= medicineExpiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (newPharmacy.Medicines.Any(x => x.Name == medicineDto.Name && x.Producer == medicineDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine newMedicine = new Medicine()
                    {
                        Category = (Category)medicineDto.Category,
                        Name = medicineDto.Name,
                        Price = (decimal)medicineDto.Price,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpiryDate,
                        Producer = medicineDto.Producer
                    };

                    newPharmacy.Medicines.Add(newMedicine);
                }

                pharmaciesToImport.Add(newPharmacy);
                sb.AppendLine(String.Format(SuccessfullyImportedPharmacy, dto.Name, newPharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(pharmaciesToImport);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
