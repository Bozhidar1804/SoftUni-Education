using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price, double grams, double calories)
            : base(name, price, grams, calories)
        {
            this.Grams = 250;
            this.Calories = 1000;
            this.CakePrice = 5;
        }
        public decimal CakePrice { get; set; }
    }
}
