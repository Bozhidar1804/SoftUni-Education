using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;
using System.Text;
using System.Xml;
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
            Console.WriteLine(GetTotalSalesByCustomer(context));
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

        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarWithDistanceExportDto[] carsWithDistance = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(c => new CarWithDistanceExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            return SerializeToXml(carsWithDistance, "cars");
        }

        // Problem 15 DTO is with ATTRIBUTES, not elements
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarsFromMakeBmwExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            return SerializeToXml(cars, "cars", true);
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            return SerializeToXml(suppliers, "suppliers");
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarWithPartsExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.Select(pc => new PartsForCarsExportDto()
                    {
                        Name = pc.Part.Name,
                        Price = Math.Round(pc.Part.Price, 2)
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            return SerializeToXml(cars, "cars");
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersBeforeDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                        ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                        : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    }).ToArray()
                }).ToArray();

            var customersDto = customersBeforeDto
                .OrderByDescending(c => c.SalesInfo.Sum(c => c.Prices))
                .Select(dto => new CustomerExportDto()
                {
                    FullName = dto.FullName,
                    BoughtCars = dto.BoughtCars,
                    SpentMoney = dto.SalesInfo.Sum(s => (decimal)s.Prices)
                }).ToArray();

            return SerializeToXml(customersDto, "customers");
        }



        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            StringBuilder sb = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = omitDeclaration,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using (StringWriter stringWriter = new StringWriter(sb, CultureInfo.InvariantCulture))
            using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
                } catch (Exception)
                {
                    throw;
                }
            }

            return sb.ToString();
        }
    }
}