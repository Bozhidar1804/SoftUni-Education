namespace _06FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            AddMembersToLists(n, citizens, rebels);

            MembersBuyFood(citizens, rebels);

            int totalFood = 0;
            totalFood = GetTotalFood(citizens, rebels, totalFood);
            Console.WriteLine(totalFood);
        }
        private static int GetTotalFood(List<Citizen> citizens, List<Rebel> rebels, int totalFood)
        {
            foreach (Citizen c in citizens)
            {
                totalFood += c.Food;
            }
            foreach (Rebel r in rebels)
            {
                totalFood += r.Food;
            }

            return totalFood;
        }
        private static void MembersBuyFood(List<Citizen> citizens, List<Rebel> rebels)
        {
            string targetName;
            while ((targetName = Console.ReadLine()) != "End")
            {
                if (citizens.Any(cit => cit.Name == targetName))
                {
                    citizens.First(cit => cit.Name == targetName).BuyFood();
                } else if (rebels.Any(reb => reb.Name == targetName))
                {
                    rebels.First(reb => reb.Name == targetName).BuyFood();
                }
                
            }
        }

        private static void AddMembersToLists(int n, List<Citizen> citizens, List<Rebel> rebels)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    rebels.Add(rebel);
                }
                else if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    citizens.Add(citizen);
                }
            }
        }
    }
}