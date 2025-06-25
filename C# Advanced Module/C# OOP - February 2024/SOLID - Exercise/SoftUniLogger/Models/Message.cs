using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Models
{
    public class Message
    {
        public Message(LogEntryLevel logEntryLevel, string logMessage)
        {
            LogEntryLevel = logEntryLevel;
            LogMessage = logMessage;
        }

        public Message(LogEntryLevel logEntryLevel, string logMessage, DateTime dateTime)
            : this(logEntryLevel, logMessage)
        {
            DateTime = dateTime;
        }

        public DateTime DateTime { get; set; } = DateTime.Now;
        public LogEntryLevel LogEntryLevel { get; set; }
        public string LogMessage { get; set; }
    }
}
