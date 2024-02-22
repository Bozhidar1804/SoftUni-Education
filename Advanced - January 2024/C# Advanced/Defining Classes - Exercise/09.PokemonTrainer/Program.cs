namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command = "";
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] commandArr = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = commandArr[0];
                string pokemonName = commandArr[1];
                string element = commandArr[2];
                int health = int.Parse(commandArr[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                if (trainers.Exists(t => t.Name == trainerName))
                {
                    Trainer currentTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                    currentTrainer.Pokemons.Add(pokemon);
                } else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string element = command;

                foreach (Trainer trainer in trainers)
                {
                    bool hasValidPokemon = false;
                    foreach (Pokemon pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == element)
                        {
                            hasValidPokemon = true;
                            continue;
                        }
                    }
                    if (hasValidPokemon)
                    {
                        trainer.Badges++;
                    } else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(pokemon);
                                if (trainer.Pokemons.Count == 0) { break; }
                            }
                        }
                    }
                }
            }

            trainers.OrderByDescending(x => x.Badges).ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Badges} {x.Pokemons.Count}"));
        }
    }
}