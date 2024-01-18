namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> pairs = new Dictionary<string, Dictionary<string, List<string>>>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!pairs.ContainsKey(continent))
                {
                    pairs.Add(continent, new Dictionary<string, List<string>>());
                    pairs[continent].Add(country, new List<string>());
                    pairs[continent][country].Add(city);
                } else if (pairs.ContainsKey(continent))
                {
                    if (pairs[continent].ContainsKey(country))
                    {
                        pairs[continent][country].Add(city);
                    } else if (!pairs[continent].ContainsKey(country))
                    {
                        pairs[continent].Add(country, new List<string>());
                        pairs[continent][country].Add(city);
                    }
                }
            }

            foreach (var continent in pairs)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                } 
            }
        }
    }
}