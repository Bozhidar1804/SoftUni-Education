namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = "";
            int wonBattles = 0;

            while (command != "End of battle" || energy <= 0)
            {
                command = Console.ReadLine();
                if (command == "End of battle" && energy >= 0)
                {
                    Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
                    break;
                }
                if (wonBattles % 3 == 0)
                {
                    energy += wonBattles;
                }

                int currentEnergy = int.Parse(command);
                if (energy >= currentEnergy)
                {
                    energy -= currentEnergy;
                    wonBattles++;
                } else if (energy < currentEnergy || energy <= 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");
                    break;
                }
            }
        }
    }
}