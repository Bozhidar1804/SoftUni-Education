namespace _03._Phone_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();
            string command = "";

            while (command != "End")
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] splitCommand = command.Split();
                string word = splitCommand[0];
                string phone = splitCommand[2];

                if (word == "Add")
                {
                    bool phoneExists = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == phone)
                        {
                            phoneExists = true;
                            break;
                        }
                    }
                    if (phoneExists)
                    {
                        continue;
                    } else
                    {
                        list.Add(phone);

                    }
                } else if (word == "Remove")
                {
                    bool phoneExists = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == phone)
                        {
                            phoneExists = true;
                            break;
                        }
                    }
                    if (phoneExists)
                    {
                        list.Remove(phone);
                    }
                } else if (word == "Bonus")
                {
                    string[] nextSplit = splitCommand[3].Split(":");
                    string oldPhone = nextSplit[0];
                    string newPhone = nextSplit[1];

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == oldPhone)
                        {
                            list.Insert(i + 1, newPhone);
                            break;
                        }
                    }
                } else if (word == "Last")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == phone)
                        {
                            list.Add(phone);
                            list.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}