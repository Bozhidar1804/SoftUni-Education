namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] commandArr = Console.ReadLine().Split(" ");
                string color = commandArr[0];
                string[] clothes = commandArr[2].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (string item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 1);
                    } else
                    {
                        wardrobe[color][item]++;
                    }
                }
            }

            string[] search = Console.ReadLine().Split(" ");

            foreach (KeyValuePair<string, Dictionary<string, int>> kvp in wardrobe)
            {
                string color = search[0];
                string item = search[1];
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (KeyValuePair<string, int> kvp2 in kvp.Value)
                {
                    if (kvp.Key == color && kvp2.Key == item)
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value} (found!)");
                    } else
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value}");
                    }
                }
            }
        }
    }
}