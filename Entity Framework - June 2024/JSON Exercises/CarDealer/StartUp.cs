using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using CarDealer;
using CarDealer.DTOs.Import;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            string parts = File.ReadAllText("../../../Datasets/parts.json");
            string cars = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(context, cars));
        }

        // Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        // Problem 10
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

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<ImportCarDto> carsDtos = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            HashSet<Car> cars = new HashSet<Car>();
            HashSet<PartCar> partsCars = new HashSet<PartCar>();

            foreach (var carDto in carsDtos)
            {
                Car newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                cars.Add(newCar);
                foreach (var partId in carDto.PartsId.Distinct())
                {
                    partsCars.Add(new PartCar()
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

    }
}