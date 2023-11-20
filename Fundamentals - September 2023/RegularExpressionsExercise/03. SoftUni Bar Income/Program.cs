using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[^|$%.]*?%(?<name>[A-Z][a-z]+)%[^|$%.]*?<(?<product>[A-Za-z]+)>[^|$%.]*?(?<random>([A-za-z]+)?)\|(?<count>\d+)\|[^|$%.]*?(?<random2>([A-za-z]+)?)(?<price>\d+(\.\d+)?)\$[^|$%.]*?";
            Regex regex = new Regex(pattern);
            string command = "";
            double totalIncome = 0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = regex.Match(command);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                string product = match.Groups["product"].Value;
                int count = int.Parse(match.Groups["count"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                double currentSum = count * price;

                Console.WriteLine($"{name}: {product} - {currentSum:F2}");

                totalIncome += currentSum;
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}