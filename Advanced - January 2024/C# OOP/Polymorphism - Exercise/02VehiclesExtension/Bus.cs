using _01Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public void DriveWithPeople(double distance)
        {
            var totalConsumptionPerTravel = distance * (FuelConsumption + fuelConsumptionModifier);
            if (FuelQuantity >= totalConsumptionPerTravel)
            {
                FuelQuantity -= totalConsumptionPerTravel;
                Console.WriteLine($"Bus travelled {distance} km");
            } else
            {
                throw new ArgumentException("Bus needs refueling");
            }
        }

        /*
        public override void Drive(double distance)
        {
            FuelConsumption += fuelConsumptionModifier;
            base.Drive(distance);
            FuelConsumption -= fuelConsumptionModifier;
        }

        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        } */
    }
}
