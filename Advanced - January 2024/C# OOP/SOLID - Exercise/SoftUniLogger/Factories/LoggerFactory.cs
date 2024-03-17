using SoftUniLogger.Appenders;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Layouts;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Factories
{
    public class LoggerFactory
    {
        public ILogger CreateLogger(string type)
        {
            ILayout layout;
            IAppender appender;

            layout = new SimpleLayout();
            switch (type)
            {
                case "console":
                    appender = new ConsoleAppender(layout);
                    break;
                case "file":
                    appender = new FileAppender(layout);
                    break;
                default:
                    throw new ArgumentException("Invalid appender type");
                    break;
            }

            return new SoftUniLogger.Loggers.Logger(appender);
        }
    }
}
