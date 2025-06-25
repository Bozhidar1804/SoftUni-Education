using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"@#+[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1}@#+";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    char[] inputArr = input.ToCharArray();
                    string concatenation = "";
                    for (int j = 0; j < inputArr.Length; j++)
                    {
                        if (char.IsDigit(inputArr[j]))
                        {
                            concatenation += inputArr[j];
                        }
                    }

                    if (concatenation.Length == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    } else
                    {
                        Console.WriteLine($"Product group: {concatenation}");
                    }
                } else 
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
            }
        }
    }
}