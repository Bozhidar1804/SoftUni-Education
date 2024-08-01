namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            throw new NotImplementedException();
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicinesToExport = context.Medicines
                .Where(m => (int)m.Category == medicineCategory)
                .Where(m => m.Pharmacy.IsNonStop == true)
                .Select(m => new ExportMedicineDto()
                {
                    Name = m.Name,
                    Price = m.Price.ToString(),
                    Pharmacy = new ExportPharmacyDto()
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .ToArray();

            return JsonConvert.SerializeObject(medicinesToExport, Formatting.Indented);
        }
    }
}
