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
    }
}
