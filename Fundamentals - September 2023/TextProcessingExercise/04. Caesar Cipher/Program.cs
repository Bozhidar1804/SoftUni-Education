using System.Text;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder cipherBuilder = new StringBuilder();
            
            for (int i = 0; i < input.Length; i++)
            {
                char original = input[i];
                cipherBuilder.Append((char)(original + 3));
            }

            Console.WriteLine(cipherBuilder);
        }
    }
}