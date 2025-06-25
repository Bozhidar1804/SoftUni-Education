using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Appenders.Interfaces
{
    public interface IAppender
    {
        public void Append(Message message);
        public LogEntryLevel LogLevel { get; set; }

        public string Type { get; set; }
        public ILayout layoutOfAppender { get; set; }
        public int MessagesAppended { get; set; }
        public int FileSize { get; set; }
    }
}
