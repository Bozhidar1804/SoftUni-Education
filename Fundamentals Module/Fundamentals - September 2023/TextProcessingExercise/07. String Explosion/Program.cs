using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = StringExplosion(input);
            Console.WriteLine(result);
        }

        public static string StringExplosion (string input)
        {
            StringBuilder result = new StringBuilder();

            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    result.Append(input[i]);
                } else if (strength == 0)
                {
                    result.Append(input[i]);
                } else
                {
                    strength--;
                }
            }

            return result.ToString();
        }
    }
}