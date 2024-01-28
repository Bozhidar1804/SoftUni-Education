using System.Xml.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> ValidNameCheck = (name, n) =>
            {
                bool result = false;
                char[] nameArr = name.ToCharArray();
                int sum = 0;
                foreach (char c in nameArr)
                {
                    sum += c;
                }

                if (sum >= n)
                {
                    result = true;
                }
                return result;
            };

            Func<Func<string, int, bool>, string[], int, string> GetValidName = (ValidNameCheck, names, n) =>
            {
                string output = "";

                foreach(string name in names)
                {
                    if (ValidNameCheck(name, n))
                    {
                        output = name;
                        break;
                    }
                }

                return output;
            };

            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ");
            Console.WriteLine(GetValidName(ValidNameCheck, names, n));
            
        }
    }
}