using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using CarDealer;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            string parts = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(context, parts));
        }

        // Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        // Problem 02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            // 1. Deserialize to a List of parts
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            // 2. Get an array of valid Ids
            var validSupplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            // 3.Filter parts based on valid Ids
            var partsWithValidSuppliers = parts
                .Where(p => validSupplierIds.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(partsWithValidSuppliers);
            context.SaveChanges();

            return $"Successfully imported {partsWithValidSuppliers.Length}";
        }
    }
}