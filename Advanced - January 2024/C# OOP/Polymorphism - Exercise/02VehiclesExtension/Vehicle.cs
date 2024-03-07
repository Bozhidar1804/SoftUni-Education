using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Vehicles
{
    public abstract class Vehicle : IDrivable, IRefuable
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Vehicle (double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Tank capacity must be a positive number");
                }
                tankCapacity = value;
            }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                if (value <= TankCapacity)
                {
                    fuelQuantity = value;
                } else
                {
                    fuelQuantity = 0;
                }
            }
        }
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Consumption must be a positive number");
                }
                fuelConsumption = value;
            }
        }

        public virtual void Drive(double distance)
        {
            double totalFuelConsumption = FuelConsumption * distance;
            if (totalFuelConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= totalFuelConsumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            FuelQuantity += fuel;
        }
    }
}
