using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string users = File.ReadAllText("../../../Datasets/users.xml");
            string products = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportProducts(context, products));
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserImportDto[]),
                    new XmlRootAttribute("Users"));

            UserImportDto[] usersDtos;

            using (var reader = new StringReader(inputXml))
            {
                usersDtos = (UserImportDto[])xmlSerializer.Deserialize(reader);
            }

            User[] users = usersDtos
                .Select(u => new User()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                }).ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductImportDto[]),
                    new XmlRootAttribute("Products"));

            ProductImportDto[] productsDtos;
            using (var reader = new StringReader(inputXml))
            {
                productsDtos = (ProductImportDto[])xmlSerializer.Deserialize(reader);
            }

            int[] validUserIds = context.Users
                .Select(u => u.Id)
                .ToArray();

            Product[] products = productsDtos
                .Where(p => validUserIds.Contains(p.SellerId) && validUserIds.Contains(p.BuyerId))
                .Select(p => new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                }).ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}