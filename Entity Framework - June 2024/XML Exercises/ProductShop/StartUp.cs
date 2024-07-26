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
            Console.WriteLine(ImportUsers(context, users));
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
    }
}