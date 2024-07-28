using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data
{
    public class DataConstraints
    {
        // byte -> [0; 255] -> 8-bit -> Higher memory efficiency
        // Product
        public const byte ProductNameMinLength = 9;
        public const byte ProductNameMaxLength = 30;
        public const string ProductPriceMinValue = "5.00";
        public const string ProductPriceMaxValue = "1000.00";

        // Address
        public const byte StreetNameMinLength = 10;
        public const byte StreetNameMaxLength = 20;

        public const byte CityNameMinLength = 5;
        public const byte CityNameMaxLength = 15;

        public const byte CountryNameMinLength = 5;
        public const byte CountryNameMaxLength = 15;

        // Client
        public const byte ClientNameMinLength = 10;
        public const byte ClientNameMaxLength = 25;
        public const byte NumberVatMinLength = 10;
        public const byte NumberVatMaxLength = 15;

        // Invoice
        public const int InvoiceMinValue = 1_000_000_000;
        public const int InvoiceMaxValue = 1_500_000_000;
        public const int InvoiceCurrencyTypeMinValue = (int)CurrencyType.BGN;
        public const int InvoiceCurrencyTypeMaxValue = (int)CurrencyType.USD;
    }
}
