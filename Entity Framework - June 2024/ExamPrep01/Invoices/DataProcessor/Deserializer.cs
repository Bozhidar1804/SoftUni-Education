namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Invoices.Data;
    using Invoices.Utilities;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using Newtonsoft.Json;
    using System.Globalization;
    using Invoices.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Clients";

            ICollection<Client> clientsToImport = new List<Client>();

            ImportClientDto[] deserializedClients = xmlHelper.Deserialize<ImportClientDto[]>(xmlString, xmlRoot);

            foreach (ImportClientDto clientDto in deserializedClients)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Address> addressesToImport = new List<Address>();

                foreach (ImportAddressDto addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address newAddress = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };

                    addressesToImport.Add(newAddress);
                }

                Client newClient = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                    Addresses = addressesToImport
                };

                clientsToImport.Add(newClient);
                sb.AppendLine(String.Format(SuccessfullyImportedClients, clientDto.Name));
            }

            context.Clients.AddRange(clientsToImport);
            context.SaveChanges();

            return sb.ToString();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportInvoiceDto[] invoicesDtos = JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString);
            List<Invoice> invoicesToImport = new List<Invoice>();
            
            foreach (ImportInvoiceDto dto in invoicesDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isIssueDateValid = DateTime.TryParse(dto.IssueDate, CultureInfo.InvariantCulture, DateTimeStyles.None,
                            out DateTime issueDate);
                bool isDueDateValid = DateTime.TryParse(dto.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None,
                            out DateTime dueDate);

                if (isIssueDateValid == false || isDueDateValid == false || DateTime.Compare(dueDate, issueDate) < 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Clients.Any(cl => cl.Id == dto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice newInvoice = new Invoice()
                {
                    Number = dto.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = dto.Amount,
                    CurrencyType = (CurrencyType)dto.CurrencyType,
                    ClientId = dto.ClientId
                };

                invoicesToImport.Add(newInvoice);
                sb.AppendLine(String.Format(SuccessfullyImportedInvoices, dto.Number));
            }

            context.Invoices.AddRange(invoicesToImport);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {


            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
