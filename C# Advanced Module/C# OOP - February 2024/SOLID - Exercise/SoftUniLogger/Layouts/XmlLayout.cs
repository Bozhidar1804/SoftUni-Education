using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SoftUniLogger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format(Message message)
        {
            XElement logEntry = new XElement("log",
                new XElement("date", message.DateTime), 
                new XElement("level", message.LogEntryLevel), 
                new XElement("message", message.LogMessage));
            return logEntry.ToString();
        }
    }
}
