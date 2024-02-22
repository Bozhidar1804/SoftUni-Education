namespace _10._Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(" ").ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArr = command.Split(";");
                string action = commandArr[0];
                string filter = commandArr[1];
                string value = commandArr[2];

                if (action == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                } else
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(" ", people)}");
            }
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return p => p.StartsWith(value);
                case "Ends with":
                    return p => p.EndsWith(value);
                case "Length":
                    return p => p.Length == int.Parse(value);
                case "Contains":
                    return p => p.Contains(value);
                default:
                    return default;
            }
        }
    }
}