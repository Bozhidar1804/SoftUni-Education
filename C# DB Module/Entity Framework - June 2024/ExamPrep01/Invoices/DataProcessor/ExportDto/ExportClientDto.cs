using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientDto
    {
        [XmlAttribute(nameof(InvoicesCount))]
        public int InvoicesCount { get; set; }

        [XmlElement(nameof(ClientName))]
        public string ClientName { get; set; }

        [XmlElement(nameof(VatNumber))]
        public string VatNumber { get; set; }

        [XmlArray(nameof(Invoices))]
        public ExportInvoiceDto[] Invoices { get; set; }
    }
}
