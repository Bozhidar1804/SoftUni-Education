using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;

namespace SoftUniLogger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout _layout;
        public ILayout layoutOfAppender { get; set; }
        public int FileSize { get; set; }
        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
            layoutOfAppender = _layout;
        }

        public LogEntryLevel LogLevel { get; set; }
        public int MessagesAppended { get; set; }
        public string Type { get; set; } = "ConsoleAppender";
        public void Append(Message message)
        {
            Console.WriteLine(_layout.Format(message));
        }
    }
}
