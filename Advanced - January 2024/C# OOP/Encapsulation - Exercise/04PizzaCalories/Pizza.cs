using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PizzaCalories
{
    internal class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public Dough Dough { get; set; }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            } 
        }

        public IReadOnlyCollection<Topping> Toppings { get { return toppings; } }

        public void AddToppings(Topping topping)
        {
            toppings.Add(topping);
            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public double TotalCalories
        {
            get
            {
                double sumCalories = Dough.CalculateCalories();
                foreach (Topping topping in toppings)
                {
                    sumCalories += topping.CalculateCalories();
                }
                return sumCalories;
            }
        }
    }
}
