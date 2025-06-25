using System.Text;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            StringBuilder output = new StringBuilder();

            foreach (string word in input)
            {
                int length = word.Length;

                for (int i = 0; i < length; i++)
                {
                    output.Append(word);
                }
            }
            Console.WriteLine(output);
        }
    }
}