using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout _layout;
        public string FilePath { get; set; } = $"..\\..\\..\\{DateTime.Now:yyyyMMddhhmmss}.txt";
        public string Type { get; set;} = "FileAppender";
        public ILayout layoutOfAppender { get; set; }
        public int MessagesAppended { get; set; }
        public int FileSize { get; set; }
        public FileAppender(ILayout layout)
        {
            _layout = layout;
            layoutOfAppender = _layout;
        }

        public FileAppender(ILayout layout, string filePath)
            : this(layout)
        {
            FilePath = filePath;
        }
        public LogEntryLevel LogLevel { get; set; }
        public void Append(Message message)
        {
            string formattedLogEntry = _layout.Format(message);
            try
            {
                File.AppendAllText(FilePath, formattedLogEntry + Environment.NewLine);
                byte[] asciiBytes = Encoding.ASCII.GetBytes(formattedLogEntry);
                int total = 0;
                Array.ForEach(asciiBytes, delegate (byte i) { if ((i > 65 && i < 90) || (i > 97 && i < 122)) { total += i; } });
                FileSize += total;
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
