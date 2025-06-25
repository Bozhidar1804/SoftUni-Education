using System.Text;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string command;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandArr = command.Split(">>>");
                string action = commandArr[0];

                if (action == "Contains")
                {
                    string substring = commandArr[1];
                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    } else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                } else if (action == "Flip")
                {
                    string type = commandArr[1];
                    int start = int.Parse(commandArr[2]);
                    int end = int.Parse(commandArr[3]);
                    
                    if (type == "Upper")
                    {
                        key = ToUpper(start, end, key);
                    } else if (type == "Lower")
                    {
                        key = ToLower(start, end, key);
                    }

                    Console.WriteLine(key);
                } else if (action == "Slice")
                {
                    int start = int.Parse(commandArr[1]);
                    int end = int.Parse(commandArr[2]);

                    key = Slice(start, end, key);
                    Console.WriteLine(key);
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }

        public static string ToUpper(int start, int end, string key)
        {
            string result = "";
            int finalPoint = key.Length - 1;

            string prefix = key.Substring(0, start);
            string middle = key.Substring(start, end - start).ToUpper();
            string suffix = key.Substring(end);

            result = prefix + middle + suffix;
            return result;
        }

        public static string ToLower(int start, int end, string key)
        {
            string result = "";
            int finalPoint = key.Length - 1;

            string prefix = key.Substring(0, start);
            string middle = key.Substring(start, end - start).ToLower();
            string suffix = key.Substring(end);

            result = prefix + middle + suffix;
            return result;
        }

        public static string Slice(int start, int end, string key)
        {
            return key.Remove(start, end - start); ;
        }
    }
}