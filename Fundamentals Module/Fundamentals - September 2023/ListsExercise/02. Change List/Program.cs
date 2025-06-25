namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = ChangeList(ints);
            foreach(int i in result)
            {
                Console.Write($"{i} ");
            }
        }

        private static List<int> ChangeList(List<int> ints)
        {
            string command = "";

            while (command != "end")
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    continue;
                }

                if (command.Contains("Delete"))
                {
                    string[] splitCommand = command.Split();
                    int delete = int.Parse(splitCommand[1]);
                    for (int i = 0; i < ints.Count; i++)
                    {
                        if (ints[i] == delete)
                        {
                            ints.RemoveAt(i);
                        }
                    }
                }
                else if (command.Contains("Insert"))
                {
                    string[] splitCommand = command.Split();
                    int number = int.Parse(splitCommand[1]);
                    int position = int.Parse(splitCommand[2]);
                    ints.Insert(position, number);
                }
            }

            return ints;
        }
    }
}