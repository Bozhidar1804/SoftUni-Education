namespace _03._Messages_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string command = "";
            List<User> users = new List<User>();

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArr = command.Split("=");
                string action = commandArr[0];

                if (action == "Add")
                {
                    string username = commandArr[1];
                    int sent = int.Parse(commandArr[2]);
                    int received = int.Parse(commandArr[3]);

                    User testUser = users.FirstOrDefault(x => x.Username == username);

                    if (testUser is not null)
                    {

                    } else if (testUser is null)
                    {
                        User currentUser = new User(username, sent, received);
                        users.Add(currentUser);
                    }
                } else if (action == "Message")
                {
                    string sender = commandArr[1];
                    string receiver = commandArr[2];

                    User Sender = users.FirstOrDefault(x => x.Username == sender);
                    User Receiver = users.FirstOrDefault(x => x.Username == receiver);

                    if (Sender is not null && Receiver is not null)
                    {
                        Sender.Sent++;
                        Receiver.Received++;
                        if ((Sender.Sent + Sender.Received) >= capacity)
                        {
                            users.Remove(Sender);
                            Console.WriteLine($"{Sender.Username} reached the capacity!");
                        }
                        if ((Receiver.Sent + Receiver.Received) >= capacity)
                        {
                            users.Remove(Receiver);
                            Console.WriteLine($"{Receiver.Username} reached the capacity!");
                        }
                    }
                } else if (action == "Empty")
                {
                    string username = commandArr[1];
                    if (username == "All" && users.Count > 0)
                    {
                        users.Clear();
                        continue;
                    }

                    User currentUser = users.FirstOrDefault(x => x.Username == username);
                    if (currentUser is not null)
                    {
                        users.Remove(currentUser);
                    }
                }
            }

            if (users.Count > 0)
            {
                Console.WriteLine($"Users count: {users.Count}");
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Username} - {user.Sent + user.Received}");
                }
            } else
            {
                Console.WriteLine($"Users count: {users.Count}");
            }
        }
    }

    class User
    {
        public User (string username, int sent, int received)
        {
            Username = username;
            Sent = sent;
            Received = received;
        }

        public string Username { get; set; }

        public int Sent { get; set; }

        public int Received { get; set; }
    }
}