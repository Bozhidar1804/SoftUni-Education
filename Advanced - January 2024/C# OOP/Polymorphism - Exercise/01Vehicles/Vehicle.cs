using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Vehicles
{
    public abstract class Vehicle
    {
        public abstract string Drive(double distance);
        public abstract void Refuel(double fuel);
    }
}
