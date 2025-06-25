using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Loggers.Interfaces
{
    public interface ILogger
    {
        public void Info(DateTime datetime, string logMessage);
        public void Warning(DateTime datetime, string logMessage);
        public void Error(DateTime datetime, string logMessage);
        public void Critical(DateTime datetime, string logMessage);
        public void Fatal(DateTime datetime, string logMessage);
        public string LoggerInfo();

    }
}
