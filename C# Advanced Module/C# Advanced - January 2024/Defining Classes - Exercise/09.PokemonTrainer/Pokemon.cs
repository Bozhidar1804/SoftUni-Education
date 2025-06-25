﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon ()
        {

        }

        public Pokemon (string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
