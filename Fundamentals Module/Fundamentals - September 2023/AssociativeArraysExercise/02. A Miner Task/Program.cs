namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string command = "";

            while (command != "stop")
            {
                command = Console.ReadLine();
                if (command == "stop") break;

                string resource = command;
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, quantity);
                } else
                {
                    resources[resource] += quantity;
                }
            }

            foreach (KeyValuePair<string, int> kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            
        }
    }
}