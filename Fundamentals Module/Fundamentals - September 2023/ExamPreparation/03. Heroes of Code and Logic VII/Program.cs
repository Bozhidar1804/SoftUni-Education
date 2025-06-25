using System.Runtime.CompilerServices;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string name = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);

                Hero hero = new Hero(name, hp, mp);
                if (hero.HP <= 100 && hero.MP <= 200)
                {
                    heroes.Add(hero);
                }
            }

            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" - ");
                string action = commandArr[0];

                if (action == "CastSpell")
                {
                    string heroName = commandArr[1];
                    int mpNeeded = int.Parse(commandArr[2]);
                    string spellName = commandArr[3];
                    CastSpell(heroName, mpNeeded, spellName, heroes);
                } else if (action == "TakeDamage")
                {
                    string heroName = commandArr[1];
                    int damage = int.Parse(commandArr[2]);
                    string attacker = commandArr[3];
                    TakeDamage(heroName, damage, attacker, heroes);
                } else if (action == "Recharge")
                {
                    string heroName = commandArr[1];
                    int amount = int.Parse(commandArr[2]);
                    Recharge(heroName, amount, heroes);
                } else if (action == "Heal")
                {
                    string heroName = commandArr[1];
                    int amount = int.Parse(commandArr[2]);
                    Heal(heroName, amount, heroes);
                }
            }

            foreach (Hero hero in heroes)
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"HP: {hero.HP}");
                Console.WriteLine($"MP: {hero.MP}");
            }
        }

        public static void CastSpell (string heroName, int mpNeeded, string spellName, List<Hero> heroes) 
        {
            Hero currentHero = heroes.FirstOrDefault(x => x.Name == heroName);

            if (currentHero is not null)
            {
                if (currentHero.MP >= mpNeeded)
                {
                    currentHero.MP -= mpNeeded;
                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currentHero.MP} MP!");
                } else if (currentHero.MP < mpNeeded)
                {
                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                }
            }
        }

        public static void TakeDamage(string heroName, int damage, string attacker, List<Hero> heroes)
        {
            Hero currentHero = heroes.FirstOrDefault(x => x.Name == heroName);

            if (currentHero is not null)
            {
                if ((currentHero.HP - damage) > 0)
                {
                    currentHero.HP -= damage;
                    Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHero.HP} HP left!");
                } else if ((currentHero.HP - damage) <= 0)
                {
                    heroes.Remove(currentHero);
                    Console.WriteLine($"{heroName} has been killed by {attacker}!");
                }
            }
        }

        public static void Recharge(string heroName, int amount, List<Hero> heroes)
        {
            Hero currentHero = heroes.FirstOrDefault(x => x.Name == heroName);

            if (currentHero is not null)
            {
                if ((currentHero.MP + amount) > 200)
                {
                    int amountRecovered = 200 - currentHero.MP;
                    currentHero.MP = 200;
                    Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
                }  else if ((currentHero.MP + amount) <= 200)
                {
                    currentHero.MP += amount;
                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                }
            }
        }

        public static void Heal(string heroName, int amount, List<Hero> heroes)
        {
            Hero currentHero = heroes.FirstOrDefault(x => x.Name == heroName);

            if (currentHero is not null)
            {
                if ((currentHero.HP + amount) > 100)
                {
                    int amountRecovered = 100 - currentHero.HP;
                    currentHero.HP = 100;
                    Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
                } else if ((currentHero.HP + amount) <= 100)
                {
                    currentHero.HP += amount;
                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }
            }
        }
    }

    class Hero
    {
        public Hero (string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }

        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }
    }
}