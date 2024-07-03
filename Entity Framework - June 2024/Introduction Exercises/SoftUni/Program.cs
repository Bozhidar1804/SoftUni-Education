using SoftUni.Data;

namespace SoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine("Connection successful!");
        }
    }
}