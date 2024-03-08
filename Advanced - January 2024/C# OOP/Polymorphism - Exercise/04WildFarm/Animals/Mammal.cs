using _04WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04WildFarm.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        public string LivingRegion { get; private set; }
        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
    }
}
