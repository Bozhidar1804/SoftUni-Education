using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Customers";

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, xmlRoot);

            ICollection<Customer> customersToImport = new List<Customer>();

            foreach (ImportCustomerDto dto in customerDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer newCustomer = new Customer()
                {
                    PhoneNumber = dto.PhoneNumber,
                    FullName = dto.FullName,
                    Email = dto.Email
                };

                bool isCustomerDuplicate = customersToImport.Any(c =>
                        c.PhoneNumber == newCustomer.PhoneNumber ||
                        c.FullName == newCustomer.FullName ||
                        c.Email == newCustomer.Email);

                if (isCustomerDuplicate)
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                customersToImport.Add(newCustomer);
                sb.AppendLine(String.Format(SuccessfullyImportedCustomer, dto.FullName));
            }

            context.Customers.AddRange(customersToImport);
            context.SaveChanges();
            return sb.ToString();
        }


        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportBookingDto[] bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            ICollection<Booking> bookingsToImport = new List<Booking>();

            foreach (ImportBookingDto dto in bookingDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime bookingDate;
                bool isBookingDateValid = DateTime
                        .TryParseExact(dto.BookingDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out bookingDate);

                if (isBookingDateValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customerForBooking = context.Customers.Where(c => c.FullName == dto.CustomerName).FirstOrDefault();
                TourPackage tourPackageForBooking = context.TourPackages.Where(tp => tp.PackageName == dto.TourPackageName).FirstOrDefault();


                Booking newBooking = new Booking()
                {
                    BookingDate = bookingDate,
                    Customer = customerForBooking,
                    TourPackage = tourPackageForBooking
                };

                bookingsToImport.Add(newBooking);
                sb.AppendLine(String.Format(SuccessfullyImportedBooking, dto.TourPackageName, bookingDate.ToString("yyyy-MM-dd")));
            }

            context.Bookings.AddRange(bookingsToImport);
            context.SaveChanges();
            return sb.ToString();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
