using Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }
        void Start()
        {

        }

        void Stop()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine($"Engine start");
            sb.Append($"Breaaak!");
            return sb.ToString();
        }
    }
}
