namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(" ").ToList();

            string command = "";
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArr = command.Split(" ");
                string action = commandArr[0];
                string criteria = commandArr[1];
                string value = commandArr[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(criteria, value));
                } else if (action == "Double")
                {
                    List<string> peopleToDouble = people.FindAll(GetPredicate(criteria, value));

                    foreach (var person in peopleToDouble)
                    {
                        int index = people.FindIndex(p => p == person);
                        people.Insert(index, person);
                    }
                }
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string criteria, string value)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return p => p.StartsWith(value);
                case "EndsWith":
                    return p => p.EndsWith(value);
                case "Length":
                    return p => p.Length == int.Parse(value);
                default:
                    return default;
            }
        }
    }
}