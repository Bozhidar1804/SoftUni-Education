using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04WildFarm.Interfaces;

namespace _04WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public Animal (string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract string ProduceSound();
        public abstract void FeedIt(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
