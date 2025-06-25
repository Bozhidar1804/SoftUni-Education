using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car (string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive (string carModel, double distance, List<Car> cars)
        {
            Car car = cars.FirstOrDefault(x => x.Model == carModel);

            if (car is not null)
            {
                if (car.FuelAmount - (distance * car.FuelConsumptionPerKilometer) >= 0)
                {
                    car.FuelAmount -= distance * car.FuelConsumptionPerKilometer;
                    car.TravelledDistance += distance;
                } else if (car.FuelAmount - (distance * car.FuelConsumptionPerKilometer) < 0)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }
    }
}
