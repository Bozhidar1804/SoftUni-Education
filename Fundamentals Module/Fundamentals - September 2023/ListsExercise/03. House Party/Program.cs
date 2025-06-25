namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            HouseParty(commands, names);
        }

        private static void HouseParty(int commands, List<string> names)
        {
            int count = 0;
            while (count < commands)
            {
                string command = Console.ReadLine();
                string[] commandSplit = command.Split();
                string name = commandSplit[0];
                if (command.Contains("is going!") && !command.Contains("not") && !names.Contains(name))
                {
                    names.Add(name);
                }
                else if (names.Contains(name) && !command.Contains("not"))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else if (command.Contains("is not going!"))
                {
                    if (names.Contains(name))
                    {
                        names.Remove(name);
                        break;
                    }
                    Console.WriteLine($"{name} is not in the list!");
                    names.Remove(name);
                }
                count++;
            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}