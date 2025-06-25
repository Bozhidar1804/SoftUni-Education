using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char resultChar;
            string result;
            if (input.Length % 2 == 0)
            {
                result = MiddleCharacters(input);
                Console.WriteLine(result);

            } else if (input.Length % 2 != 0)
            {
                resultChar = MiddleChar(input);
                Console.WriteLine(resultChar);
            }
        }

        private static char MiddleChar(string input)
        {
            return input[input.Length / 2];
        }

        private static string MiddleCharacters(string input)
        {
            return input.Substring((input.Length / 2) - 1, 2);
        }
    }
}