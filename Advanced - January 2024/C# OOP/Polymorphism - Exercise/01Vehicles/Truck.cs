using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Vehicles
{
    public class Truck : Vehicle
    {
        private double fuelQuantity;
        private double litersPerKm;

        public Truck (double fuelQuantity, double litersPerKm)
        {
            FuelQuantity = fuelQuantity;
            LitersPerKm = litersPerKm + 1.6;
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
                result = $"Truck travelled {distance} km";
            } else if (FuelQuantity < fuelForTrip)
            {
                result = "Truck needs refueling";
            }
            return result;
        }

        public override void Refuel(double fuel)
        {
            fuel = fuel * 0.95;
            FuelQuantity += fuel;
        }
    }
}
