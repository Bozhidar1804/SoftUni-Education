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
            string cars = File.ReadAllText("../../../Datasets/cars.xml");
            string customers = File.ReadAllText("../../../Datasets/customers.xml");
            string sales = File.ReadAllText("../../../Datasets/sales.xml");
            Console.WriteLine(ImportSales(context, sales));
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

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]),
                    new XmlRootAttribute("Cars"));

            ImportCarDto[] importCarsDtos;
            using (var reader = new StringReader(inputXml))
            {
                importCarsDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();
            int[] validPartsIds = context.Parts
                .Select(p => p.Id)
                .Distinct()
                .ToArray();

            foreach (var dto in importCarsDtos)
            {
                Car newCar = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                int[] carPartsId = dto.PartIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                List<PartCar> carParts = new List<PartCar>();

                foreach (var id in carPartsId)
                {
                    if (validPartsIds.Contains(id))
                    {
                        carParts.Add(new PartCar()
                        {
                            Car = newCar,
                            PartId = id
                        });
                    }
                }

                newCar.PartsCars = carParts;
                cars.Add(newCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                    new XmlRootAttribute("Customers"));

            ImportCustomerDto[] importCustomerDtos;

            using (var reader = new StringReader(inputXml))
            {
                importCustomerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);
            }

            Customer[] customers = importCustomerDtos
                .Select(dto => new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver
                }).ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]),
                        new XmlRootAttribute("Sales"));

            ImportSaleDto[] importSaleDtos;

            using (var reader = new StringReader(inputXml))
            {
                importSaleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(reader);
            }

            int[] validCarIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            Sale[] sales = importSaleDtos
                .Where(dto => validCarIds.Contains(dto.CarId))
                .Select(dto => new Sale()
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount
                }).ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }
    }
}