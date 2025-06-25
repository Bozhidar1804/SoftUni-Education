namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            string a = Console.ReadLine();
            string b = Console.ReadLine();
            if (type == "int")
            {
                Console.WriteLine(GetMax(int.Parse(a), int.Parse(b)));
            } else if (type == "char")
            {
                Console.WriteLine(GetMax(char.Parse(a), char.Parse(b)));
            } else if (type == "string")
            {
                Console.WriteLine(GetMax(a, b));
            }
        }

        private static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            } else
            {
                return b;
            }
        }

        private static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private static string GetMax(string a, string b)
        {
            string result = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    result = a;
                }
                else if (b[i] > a[i])
                {
                    result = b;
                }
            }
            return result;
        }
    }
}