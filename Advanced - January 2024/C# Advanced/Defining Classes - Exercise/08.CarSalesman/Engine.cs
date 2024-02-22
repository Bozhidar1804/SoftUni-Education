using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine ()
        {

        }
        public Engine (string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = 0;
            Efficiency = "n/a";
        }

        public Engine (string model, int power, int displacement)
            : this(model, power)
        { 
            Displacement = displacement;
        }

        public Engine (string model, int power, string efficiency)
            : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine (string model, int power, int displacement, string efficiency)
            : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
