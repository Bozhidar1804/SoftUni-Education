using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
        /*<name>SNORING HP</name>
        <price>53.59</price>
        <sellerId>24</sellerId>
        <buyerId>30</buyerId>*/

    [XmlType("Product")]
    public class ProductImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("sellerId")]
        public int SellerId { get; set; }
        [XmlElement("buyerId")]
        public int BuyerId { get; set; }
    }
}
