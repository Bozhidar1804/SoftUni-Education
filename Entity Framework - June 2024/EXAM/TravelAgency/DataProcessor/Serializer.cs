using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Data.Models;
using Newtonsoft.Json;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guidesToExport = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new ExportGuideDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides.Select(tpg => new ExportTourPackageDto()
                    {
                        Name = tpg.TourPackage.PackageName,
                        Description = tpg.TourPackage.Description,
                        Price = tpg.TourPackage.Price
                    })
                    .OrderByDescending(tp => tp.Price)
                    .ThenBy(tp => tp.Name)
                    .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Length)
                .ThenBy(g => g.FullName)
                .ToArray();

            return SerializeToXml(guidesToExport, "Guides");
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


        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customersToExport = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .AsEnumerable()
                .Select(c => new ExportCustomerDto()
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                    .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                    .Select(b => new ExportBookingDto()
                    {
                        TourPackageName = b.TourPackage.PackageName,
                        Date = b.BookingDate.ToString("yyyy-MM-dd")
                    })
                    .OrderBy(b => b.Date)
                    .ToArray()
                })
                .OrderByDescending(c => c.Bookings.Length)
                .ThenBy(c => c.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customersToExport, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
