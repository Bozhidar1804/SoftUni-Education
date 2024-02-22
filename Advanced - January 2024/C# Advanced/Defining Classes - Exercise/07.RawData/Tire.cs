using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Tire
    {
        private int age;
        private float pressure;
        
        public Tire (int age, float pressure)
        {
            Age = age;
            Pressure = pressure;
        }
        public int Age { get; set; }
        public float Pressure { get; set; }
    }
}
