using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string suppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            string parts = File.ReadAllText("../../../Datasets/parts.xml");
            Console.WriteLine(ImportParts(context, parts));
        }

        // Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),
                    new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] importDtos;

            using(var reader = new StringReader(inputXml))
            {
                importDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            };

            Supplier[] suppliers = importDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                }).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                    new XmlRootAttribute("Parts"));

            ImportPartDto[] importDtos;

            using (var reader = new StringReader(inputXml))
            {
                importDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);
            }

            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            Part[] parts = importDtos
                    .Where(dto => supplierIds.Contains(dto.SupplierId))
                    .Select(dto => new Part()
                    {
                        Name = dto.Name,
                        Price = dto.Price,
                        Quantity = dto.Quantity,
                        SupplierId = dto.SupplierId
                    }).ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }
    }
}