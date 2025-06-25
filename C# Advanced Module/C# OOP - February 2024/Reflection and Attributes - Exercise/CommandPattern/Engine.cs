using CommandPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string result = String.Empty;
                try
                {
                    result = commandInterpreter.Read(input);
                } catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                Console.WriteLine(result);
            }     
        }
    }
}
