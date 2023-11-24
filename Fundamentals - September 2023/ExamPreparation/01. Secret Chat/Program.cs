namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = "";

            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] commandArr = command.Split(":|:").ToArray();
                string currentCommand = commandArr[0];

                if (currentCommand == "InsertSpace")
                {
                    int index = int.Parse(commandArr[1]);
                    input = input.Insert(index, " ");
                } else if (currentCommand == "ChangeAll")
                {
                    string substring = commandArr[1];
                    string replacement = commandArr[2];
                    input = input.Replace(substring, replacement);
                } else if (currentCommand == "Reverse")
                {
                    string substring = commandArr[1];
                    int substringIndex = input.IndexOf(substring);
                    if (substringIndex < 0)
                    {
                        Console.WriteLine("error");
                        continue;
                    } else
                    {
                        input = input.Remove(substringIndex, substring.Length);
                        string reversedSubstring = new string(substring.Reverse().ToArray());
                        input = input.Insert(substringIndex, reversedSubstring);
                    }
                }
                Console.WriteLine(input);
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}