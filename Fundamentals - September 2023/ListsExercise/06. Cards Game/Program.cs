namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstDeck.Any() && secondDeck.Any())
            {
                if (firstDeck[0] > secondDeck[0])
                {
                    firstDeck.Add(secondDeck[0]);
                    firstDeck.Insert(firstDeck.Count - 1, firstDeck[0]);
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                } else if (secondDeck[0] > firstDeck[0])
                {
                    secondDeck.Add(firstDeck[0]);
                    secondDeck.Insert(secondDeck.Count - 1, secondDeck[0]);
                    secondDeck.RemoveAt(0);
                    firstDeck.RemoveAt(0);
                } else if (firstDeck[0] == secondDeck[0])
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
            }

            if (firstDeck.Any())
            {
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            } else if (secondDeck.Any())
            {
                Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
            }
        }
    }
}