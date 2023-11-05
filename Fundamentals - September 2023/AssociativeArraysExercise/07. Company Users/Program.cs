namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" -> ");
                string company = commandArr[0];
                string id = commandArr[1];

                if (!companies.ContainsKey(company))
                {
                    companies[company] = new List<string>();
                    companies[company].Add(id);
                } else
                {
                    if (idExists(company, companies[company], id) /* companies[company].Contains[id] */)
                    {
                        continue;
                    }
                    companies[company].Add(id);
                }
            }
            
            foreach (KeyValuePair<string, List<string>> kvp in companies)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (string id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }

        public static bool idExists(string key, List<string> value, string id)
        {
            bool result = false;
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            companies.Add(key, value);
            foreach (KeyValuePair<string, List<string>> kvp in companies)
            {
                if (kvp.Value.Contains(id))
                {
                    result = true;
                }
            }

            return result;

        }
    }
}