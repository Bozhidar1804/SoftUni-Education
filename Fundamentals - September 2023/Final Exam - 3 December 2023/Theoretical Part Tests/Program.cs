using System.Security.Cryptography.X509Certificates;

namespace Theoretical_Part_Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            printText("C#");
        }
        public static void printText(string text)
        {
            Console.WriteLine("I love" + text);
        }
    }
}