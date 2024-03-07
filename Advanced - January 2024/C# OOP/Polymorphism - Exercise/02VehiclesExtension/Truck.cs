using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionModifier = 1.6;
        private const double TruckerFactor = 0.95;
        public Truck (double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base (fuelQuantity, fuelConsumption + fuelConsumptionModifier, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
            base.Refuel(TruckerFactor * fuel);
        }
    }
}
