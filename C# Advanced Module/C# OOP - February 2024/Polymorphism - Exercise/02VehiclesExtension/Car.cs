using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionModifier = 0.9;

        public Car (double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base (fuelQuantity, fuelConsumption + fuelConsumptionModifier, tankCapacity)
        {
        }

    }
}
