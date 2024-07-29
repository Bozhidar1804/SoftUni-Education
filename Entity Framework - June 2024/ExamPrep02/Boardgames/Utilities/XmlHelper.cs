using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            object? deserializedObjects = xmlSerializer.Deserialize(reader);

            if (deserializedObjects == null ||
                deserializedObjects is not T deserializedObjectTypes)
            {
                throw new InvalidOperationException();
            }

            return deserializedObjectTypes;
        }

        public string Serialize<T>(T obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            // Remove unnecessary namespace
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj);

            return sb.ToString().TrimEnd();
        }
    }
}
