namespace _03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<City> cities = new List<City>();

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] currentCity = input.Split("||");
                string name = currentCity[0];
                int population = int.Parse(currentCity[1]);
                int gold = int.Parse(currentCity[2]);

                City city = cities.FirstOrDefault(x => x.Name == name);

                if (city is not null)
                {
                    city.Population += population;
                    city.Gold += gold;
                } else
                {
                    cities.Add(new City(name, population, gold));
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currentInput = input.Split("=>");
                string command = currentInput[0];

                if (command == "Plunder")
                {
                    string town = currentInput[1];
                    int people = int.Parse(currentInput[2]);
                    int gold = int.Parse(currentInput[3]);

                    City currentCity = cities.FirstOrDefault(x => x.Name == town);

                    if (currentCity is not null)
                    {
                        currentCity.Population -= people;
                        currentCity.Gold -= gold;

                        if (currentCity.Population <= 0 || currentCity.Gold <= 0)
                        {
                            cities.Remove(currentCity);
                            Console.WriteLine($"{currentCity.Name} plundered! {gold} gold stolen, {people} citizens killed.");
                            Console.WriteLine($"{currentCity.Name} has been wiped off the map!");
                        } else
                        {
                            Console.WriteLine($"{currentCity.Name} plundered! {gold} gold stolen, {people} citizens killed.");
                        }
                    }
                } else if (command == "Prosper")
                {
                    string town = currentInput[1];
                    int gold = int.Parse(currentInput[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        continue;
                    } else
                    {
                        City currentCity = cities.FirstOrDefault(x => x.Name == town);

                        if (currentCity is not null)
                        {
                            currentCity.Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {currentCity.Name} now has {currentCity.Gold} gold.");
                        }
                    }
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            } else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class City
    {
        public City (string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }

        public int Population { get; set; }

        public int Gold { get; set; }
    }
}