using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniLogger.Appenders;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Loggers.Interfaces;
using SoftUniLogger.Models;

namespace SoftUniLogger.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> _appenders = new List<IAppender>();
        public Logger(IAppender appender)
        {
            _appenders.Add(appender);
        }

        public Logger(List<IAppender> appenders)
        {
            _appenders = appenders;
        } 

        public void AddAppender(IAppender appender)
        {
            _appenders.Add(appender);
        }
        public void Info(DateTime dateTime, string logMessage)
        {
            Log(new Message(LogEntryLevel.Info, logMessage, dateTime));
        }

        public void Warning(DateTime dateTime, string logMessage)
        {
            Log(new Message(LogEntryLevel.Warn, logMessage, dateTime));
        }

        public void Error(DateTime dateTime, string logMessage)
        {
            Log(new Message(LogEntryLevel.Error, logMessage, dateTime));
        }

        public void Critical(DateTime dateTime, string logMessage)
        {
            Log(new Message(LogEntryLevel.Critical, logMessage, dateTime));
        }

        public void Fatal(DateTime dateTime, string logMessage)
        {
            Log(new Message(LogEntryLevel.Fatal, logMessage, dateTime));
        }

        private void Log(Message message)
        {
            foreach (IAppender appender in _appenders)
            {
                if (message.LogEntryLevel >= appender.LogLevel)
                {
                    appender.Append(message);
                    appender.MessagesAppended++;
                }
            }
        }

        public string LoggerInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAppender appender in _appenders)
            {
                if (appender.Type == "ConsoleAppender")
                {
                    sb.AppendLine($"Appender type: {appender.Type}, Layout type: {appender.layoutOfAppender}, Report level: {appender.LogLevel}, Messages appended: {appender.MessagesAppended}");
                } else if (appender.Type == "FileAppender")
                {
                    sb.AppendLine($"Appender type: {appender.Type}, Layout type: {appender.layoutOfAppender}, Report level: {appender.LogLevel}, Messages appended: {appender.MessagesAppended}, File size: {appender.FileSize}");
                }
            }
            return sb.ToString();
        }
    }
}
