namespace _03Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int heroCount = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            while (heroes.Count < heroCount)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();
                if (heroType == "Druid")
                {
                    heroes.Add(new Druid(name));
                } else if (heroType == "Paladin")
                {
                    heroes.Add(new Paladin(name));
                } else if (heroType == "Rogue")
                {
                    heroes.Add(new Rogue(name));
                } else if (heroType == "Warrior")
                {
                    heroes.Add(new Warrior(name));
                } else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroesPower = heroes.Sum(h => h.Power);
            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine($"{hero.CastAbility()}");
            }

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            } else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}