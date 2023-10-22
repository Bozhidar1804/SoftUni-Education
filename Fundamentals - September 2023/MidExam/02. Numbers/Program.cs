using System.Diagnostics.SymbolStore;

namespace _02._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = "";

            while (command != "Finish")
            {
                command = Console.ReadLine();
                if (command == "Finish")
                {
                    break;
                }

                string[] splitCommand = command.Split();
                string word = splitCommand[0];
                int value = int.Parse(splitCommand[1]);

                if (word == "Add")
                {
                    sequence.Add(value);
                } else if (word == "Remove")
                {
                    bool isRemoved = false;
                    for (int i = 0; i < sequence.Count; i++)
                    {
                        if (sequence[i] == value)
                        {
                            sequence.RemoveAt(i);
                            isRemoved = true;
                            if (isRemoved)
                            {
                                break;
                            }
                        }
                    }
                } else if (word == "Replace")
                {
                    int replacement = int.Parse(splitCommand[2]);
                    bool isReplaced = false;

                    for (int i = 0; i < sequence.Count; i++)
                    {
                        if (sequence[i] == value)
                        {
                            sequence[i] = replacement;
                            isReplaced = true;
                            if(isReplaced)
                            {
                                break;
                            }
                        }
                    }
                } else if (word == "Collapse")
                {
                    for (int i = 0; i < sequence.Count; i++)
                    {
                        bool isCollapsed = false;
                        if (sequence[i] < value)
                        {
                            sequence.Remove(sequence[i]);
                            isCollapsed = true;
                            if (isCollapsed)
                            {
                                i--;
                            }
                        }
                    }
                }

            }

            foreach (int i in sequence)
            {
                Console.Write($"{i} ");
            }
        }
    }
}