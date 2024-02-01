using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo()
        {

        }
        public Cargo (int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
