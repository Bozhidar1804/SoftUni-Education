using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"!(?<command>[A-Z]{1}[a-z]{2,})!:\[(?<text>[A-z]{8,})\]";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (regex.IsMatch(input, 0))
                {
                    Match match = regex.Match(input);
                    string command = match.Groups["command"].Value;
                    string text = match.Groups["text"].Value;

                    Console.Write($"{command}: ");

                    foreach (char c in text)
                    {
                        int number = (int)c;
                        Console.Write($"{number} ");
                    }
                    Console.WriteLine();
                } else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}