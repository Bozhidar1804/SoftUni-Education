using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car()
        {

        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($" {Engine.Model}:");
            sb.AppendLine($"  Power: {Engine.Power}");
            if (Engine.Displacement is 0)
            {
                sb.AppendLine($"  Displacement: n/a");
            } else
            {
                sb.AppendLine($"  Displacement: {Engine.Displacement}");
            }

            if (Engine.Efficiency is null)
            {
                sb.AppendLine($"  Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"  Efficiency: {Engine.Efficiency}");
            }

            if (Weight is 0)
            {
                sb.AppendLine($" Weight: n/a");
            }
            else
            {
                sb.AppendLine($" Weight: {Weight}");
            }

            if (Color is null)
            {
                sb.AppendLine($" Color: n/a");
            }
            else
            {
                sb.AppendLine($" Color: {Color}");
            }

            return sb.ToString().Trim();
        }
    }
}
