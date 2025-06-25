using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Car
    {
        private string model;
        private Engine engine = new Engine();
        private Cargo cargo = new Cargo();
        private Tire[] tires;

        public Car (string model, int speed, int power, int weight, string type, float tire1Pressure, int tire1Age, float tire2Pressure, int tire2Age, float tire3Pressure, int tire3Age, float tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(weight, type);
            Tires = new Tire[4]
            {
                new Tire(tire1Age, tire1Pressure),
                new Tire(tire2Age, tire2Pressure),
                new Tire(tire3Age, tire3Pressure),
                new Tire(tire4Age, tire4Pressure),
            };
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
