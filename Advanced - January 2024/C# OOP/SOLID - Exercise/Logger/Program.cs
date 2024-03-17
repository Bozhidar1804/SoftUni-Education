using SoftUniLogger.Appenders;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Factories;
using SoftUniLogger.Layouts;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Loggers.Interfaces;
using SoftUniLogger.Models;

namespace Logger.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* ILogger consoleLogger = InitializeWithFactory(); */

            int numberOfAppenders = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new List<IAppender>();
            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ILayout layout = null;
                switch (appenderData[1])
                {
                    case "SimpleLayout":
                        layout = new SimpleLayout();
                        break;
                    case "XmlLayout":
                        layout = new XmlLayout();
                        break;
                    default:
                        Console.WriteLine("Invalid layout.");
                        break;
                }

                IAppender appender = null;
                switch (appenderData[0])
                {
                    case "ConsoleAppender":
                        appender = new ConsoleAppender(layout);
                        break;
                    case "FileAppender":
                        appender = new FileAppender(layout);
                        break;
                    default:
                        Console.WriteLine("Invalid appender.");
                        break;
                }

                if (appenderData.Length == 3)
                {
                    switch (appenderData[2])
                    {
                        case "INFO":
                            appender.LogLevel = LogEntryLevel.Info;
                            break;
                        case "WARNING":
                            appender.LogLevel = LogEntryLevel.Warn;
                            break;
                        case "ERROR":
                            appender.LogLevel = LogEntryLevel.Error;
                            break;
                        case "CRITICAL":
                            appender.LogLevel = LogEntryLevel.Critical;
                            break;
                        case "FATAL":
                            appender.LogLevel = LogEntryLevel.Fatal;
                            break;
                    }
                }
                appenders.Add(appender);
            }

            ILogger logger = new SoftUniLogger.Loggers.Logger(appenders);
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                switch (data[0])
                {
                    case "INFO":
                        logger.Info(DateTime.Parse(data[1]), data[2]);
                        break;
                    case "WARNING":
                        logger.Warning(DateTime.Parse(data[1]), data[2]);
                        break;
                    case "ERROR":
                        logger.Error(DateTime.Parse(data[1]), data[2]);
                        break;
                    case "CRITICAL":
                        logger.Critical(DateTime.Parse(data[1]), data[2]);
                        break;
                    case "FATAL":
                        logger.Fatal(DateTime.Parse(data[1]), data[2]);
                        break;
                }
            }
            Console.WriteLine(logger.LoggerInfo());
        }

        private static ILogger InitializeWithFactory()
        {
            var loggerFactory = new LoggerFactory();
            ILogger consoleLogger = loggerFactory.CreateLogger("console");
            ILogger fileLogger = loggerFactory.CreateLogger("file");
            return consoleLogger;
        }
    }
}