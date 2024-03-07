using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Vehicles
{
    public abstract class Vehicle
    {
        public double fuelQuantity;
        public double litersPerKm;
        public Vehicle (double fuelQuantity, double litersPerKm)
        {
            this.fuelQuantity = fuelQuantity;
            this.litersPerKm = litersPerKm;
        }
        public abstract string Drive(double distance);
        public abstract void Refuel(double fuel);
    }
}
