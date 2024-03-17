using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(Message message)
        {
            return $"{message.DateTime} - {message.LogEntryLevel} - {message.LogMessage}";
        }
    }
}
