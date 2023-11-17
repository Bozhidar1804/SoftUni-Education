using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<product>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)\b";
            string command = "";
            
            Regex regex = new Regex(pattern);

            List<string> boughtFurniture = new List<string>();
            double totalPrice = 0;
            bool isValid = false;

            while ((command = Console.ReadLine()) != "Purchase")
            {
                Match product = regex.Match(command);

                if (product.Success)
                {
                    double price = double.Parse(product.Groups["price"].Value);
                    int quantity = int.Parse(product.Groups["quantity"].Value);
                    totalPrice += quantity * price;

                    boughtFurniture.Add(product.Groups["product"].Value);
                } else
                {
                    continue;
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (string product in boughtFurniture)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}