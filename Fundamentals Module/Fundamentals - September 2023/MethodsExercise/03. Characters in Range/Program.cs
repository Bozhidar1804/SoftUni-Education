namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            string result = CharInRange(a, b);
            Console.WriteLine(result);
        }

        private static string CharInRange(char a, char b)
        {
            string result = "";
            char bigger;
            char smaller;
            if (a > b)
            {
                smaller = b;
                bigger = a;
                for (char i = ++smaller; i < bigger; i++)
                {
                    result += i + " ";
                }
                return result;
            }


            for (char i = ++a; i < b; i++)
            {
                result += i + " ";
            }
            return result;
        }
    }
}