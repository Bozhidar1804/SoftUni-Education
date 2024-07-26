using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Globalization;
using System.Text;
using System.Xml;
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
            string categories = File.ReadAllText("../../../Datasets/categories.xml");
            string categoriesProducts = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(GetProductsInRange(context));
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

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryImportDto[]),
                    new XmlRootAttribute("Categories"));

            CategoryImportDto[] categoriesDtos;
            using (var reader = new StringReader(inputXml))
            {
                categoriesDtos = (CategoryImportDto[])xmlSerializer.Deserialize(reader);
            }

            Category[] categories = categoriesDtos
                .Where(c => c.Name != null)
                .Select(c => new Category() { Name = c.Name })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDto[]),
                    new XmlRootAttribute("CategoryProducts"));

            CategoryProductImportDto[] categoryProductsImportDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryProductsImportDtos = (CategoryProductImportDto[])xmlSerializer.Deserialize(reader);
            }

            int[] validCategoryIds = context.Categories
                .Select(c => c.Id)
                .ToArray();

            int[] validProductIds = context.Products
                .Select(p => p.Id)
                .ToArray();

            CategoryProduct[] categoryProducts = categoryProductsImportDtos
                .Where(dto => validCategoryIds.Contains(dto.CategoryId) && validProductIds.Contains(dto.ProductId))
                .Select(dto => new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                })
                .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductsInRangeExportDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            return SerializeToXml(products, "Products");
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
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return sb.ToString();
        }
    }
}