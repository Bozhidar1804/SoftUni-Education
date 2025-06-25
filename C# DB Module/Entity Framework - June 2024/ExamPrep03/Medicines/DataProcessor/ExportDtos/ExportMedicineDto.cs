using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportMedicineDto
    {
        public string Name { get; set; } = null!;
        public string Price { get; set; }
        public ExportPharmacyDto Pharmacy { get; set; } = null!;
    }
}
