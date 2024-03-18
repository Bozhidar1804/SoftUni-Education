using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Commands
{
    public class ExitCommand : ICommand
    {
        private const int OkExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(OkExitCode);
            return null;
        }
    }
}
