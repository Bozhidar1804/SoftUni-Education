using CarManufacturer;
using System.Text;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> listYearInfo = new List<List<int>>();
            List<List<double>> listPressureInfo = new List<List<double>>();
            List<int> listHorsePower = new List<int>();
            List<double> listCubicCapacity = new List<double>();

            List<Car> cars = new List<Car>();

            Tire tires = new Tire();
            Engine engine = new Engine();

            string command = "";
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] splitted = command.Split(" ");
                List<int> yearInfo = tires.GetYearInfo(splitted);
                List<double> pressureInfo = tires.GetPressureInfo(splitted);

                listYearInfo.Add(yearInfo);
                listPressureInfo.Add(pressureInfo);
            }

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] splitted = command.Split(" ");
                listHorsePower.Add(int.Parse(splitted[0]));
                listCubicCapacity.Add(double.Parse(splitted[1]));
            }

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] splitted = command.Split(" ");
                string make = splitted[0];
                string model = splitted[1];
                int year = int.Parse(splitted[2]);
                double fuelQuantity = double.Parse(splitted[3]);
                double fuelConsumption = double.Parse(splitted[4]);
                int engineIndex = int.Parse(splitted[5]);
                int tiresIndex = int.Parse(splitted[6]);

                int horsePower = listHorsePower[engineIndex];
                double totalPressure = tires.GetTotalPressure(listPressureInfo, tiresIndex);

                Car car = new Car(make, model, year, horsePower, fuelQuantity, fuelConsumption, engineIndex, tiresIndex, totalPressure);
                cars.Add(car);
            }

            List<Car> specialCars = new List<Car>();

            foreach (Car car in cars)
            {
                if (car.Year >= 2017 && car.HorsePower > 330 && car.TotalPressure > 9 && car.TotalPressure < 10)
                {
                    car.FuelQuantity = car.Drive20Kilometers(car.FuelQuantity, car.FuelConsumption);
                    specialCars.Add(car);
                }
            }

            foreach (Car car in specialCars)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {car.HorsePower}");
                sb.AppendLine($"FuelQuantity: {car.FuelQuantity}");
                Console.WriteLine(sb);
            }
        }
    }
}