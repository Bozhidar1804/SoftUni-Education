using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PizzaCalories
{
    internal class Topping
    {
        private readonly string toppingType;
        private double weight;
        private const double baseCalories = 2;

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get { return toppingType; }
            init
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double BaseCalories { get; set; }
        public double CalculateCalories()
        {
            switch(toppingType.ToLower())
            {
                case "meat": BaseCalories = 1.2; break;
                case "veggies": BaseCalories = 0.8; break;
                case "cheese": BaseCalories = 1.1; break;
                case "sauce": BaseCalories = 0.9; break;
            }

            return (BaseCalories * 2) * Weight;
        }
    }
}
