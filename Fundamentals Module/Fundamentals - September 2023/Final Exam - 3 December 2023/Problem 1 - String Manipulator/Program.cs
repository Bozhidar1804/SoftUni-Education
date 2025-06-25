using System.Text;

namespace Problem_1___String_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" ");
                string action = commandArr[0];
                char[] inputArr = input.ToCharArray();

                if (action == "Translate")
                {
                    char[] c = commandArr[1].ToCharArray();
                    char[] replacement = commandArr[2].ToCharArray();

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (inputArr[i] == c[0])
                        {
                            inputArr[i] = replacement[0];
                        }
                    }

                    input = new string(inputArr);
                    Console.WriteLine(input);
                } else if (action == "Includes")
                {
                    string substring = commandArr[1];
                    if (input.Contains(substring))
                    {
                        Console.WriteLine("True");
                    } else
                    {
                        Console.WriteLine("False");
                    }
                } else if (action == "Start")
                {
                    string substring = commandArr[1];
                    if (input.StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    } else
                    {
                        Console.WriteLine("False");
                    }
                } else if (action == "Lowercase")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                } else if (action == "FindIndex")
                {
                    char[] cArr = commandArr[1].ToCharArray();
                    char c = cArr[0];
                    int lastIndex = input.LastIndexOf(c);
                    Console.WriteLine(lastIndex);
                } else if (action == "Remove")
                {
                    int startIndex = int.Parse(commandArr[1]);
                    int count = int.Parse(commandArr[2]);
                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }
            }

        }
    }
}