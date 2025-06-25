using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PizzaCalories
{
    internal class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private const double baseCalories = 2;

        public Dough (string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            BaseCalories = baseCalories;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            } private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            } private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double BaseCalories { get; }
        public double CalculateCalories()
        {
            double modifierFlour = 0;
            switch (flourType.ToLower())
            {
                case "white": modifierFlour = 1.5; break;
                case "wholegrain": modifierFlour = 1; break;
            }
            double modifierBaking = 0;
            switch (bakingTechnique.ToLower())
            {
                case "crispy": modifierBaking = 0.9; break;
                case "chewy": modifierBaking = 1.1; break;
                case "homemade": modifierBaking = 1; break;
            }

            return modifierFlour * modifierBaking * (Weight * BaseCalories);
        }
    }
}
