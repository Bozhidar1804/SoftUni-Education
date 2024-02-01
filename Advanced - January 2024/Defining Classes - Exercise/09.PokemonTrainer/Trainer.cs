using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons = new List<Pokemon>();

        public Trainer ()
        {

        }

        public Trainer (string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }

        public Trainer (string name, int badges, List<Pokemon> pokemons)
        {
            Name = name;
            Badges = badges;
            Pokemons = pokemons;
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
