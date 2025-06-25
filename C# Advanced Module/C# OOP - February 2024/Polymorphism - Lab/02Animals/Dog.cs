using Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }
        public override string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood}\nDJAAF";
        }
    }
}
