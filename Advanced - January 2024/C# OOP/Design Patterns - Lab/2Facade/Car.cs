using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Facade
{
    public class Car
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"CarType: {Type}, ...";
        }
    }
}
