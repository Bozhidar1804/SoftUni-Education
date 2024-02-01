using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Engine
    {
        private int speed;
        private int power;

        public Engine()
        {

        }
        public Engine (int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        
        public int Speed;
        public int Power;
    }
}
