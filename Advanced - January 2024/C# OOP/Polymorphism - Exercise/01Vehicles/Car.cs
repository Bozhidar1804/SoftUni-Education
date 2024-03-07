using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Vehicles
{
    public class Car : Vehicle, IDrivable, IRefuable
    {
        private const double fuelConsumptionModifier = 0.9;

        public Car (double fuelQuantity, double litersPerKm)
            : base (fuelQuantity, litersPerKm + fuelConsumptionModifier)
        {
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set { fuelQuantity = value; }
        }
        public double LitersPerKm
        {
            get { return litersPerKm; }
            private set { litersPerKm = value; }
        }
        public override string Drive(double distance)
        {
            string result = "";
            double fuelForTrip = LitersPerKm * distance;

            if (FuelQuantity >= fuelForTrip)
            {
                FuelQuantity -= fuelForTrip;
                result = $"Car travelled {distance} km";
            } else if (FuelQuantity < fuelForTrip)
            {
                result = "Car needs refueling";
            }

            return result;
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
    }
}
