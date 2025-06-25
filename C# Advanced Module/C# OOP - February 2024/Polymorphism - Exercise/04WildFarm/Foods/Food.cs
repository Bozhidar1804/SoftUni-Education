using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04WildFarm.Interfaces;

namespace _04WildFarm
{
    public abstract class Food : IFood
    {
        public int Quantity { get; set; }
        public Food (int quantity)
        {
            Quantity = quantity;
        }
    }
}
