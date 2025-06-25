using _04WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04WildFarm.Animals
{
    public abstract class Bird : Animal, IBird
    {
        public double WingSize { get; set; }
        public Bird (string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.WingSize}, {base.Weight}, {base.FoodEaten}]");
            return $"{base.ToString()} {sb}";
        }
    }
}
