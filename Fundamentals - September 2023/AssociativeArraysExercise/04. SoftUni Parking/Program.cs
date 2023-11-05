namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> registeredUsers = new Dictionary<string, string>();
            int counter = 0;

            while (counter < n)
            {
                string[] commandArr = Console.ReadLine().Split(" ");
                string currentCommand = commandArr[0];
                string username = commandArr[1];

                if (currentCommand == "register")
                {
                    string licensePlate = commandArr[2];
                    if (!registeredUsers.ContainsKey(username))
                    {
                        registeredUsers.Add(username, licensePlate);
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    } else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }

                } else if (currentCommand == "unregister")
                {
                    if (!registeredUsers.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    } else
                    {
                        registeredUsers.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
                counter++;
            }

            foreach (KeyValuePair<string, string> kvp in registeredUsers)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}