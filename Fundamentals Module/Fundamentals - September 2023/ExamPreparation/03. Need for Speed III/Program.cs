using System.Reflection.Metadata.Ecma335;

namespace _03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string name = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                Car car = new Car(name, mileage, fuel);
                cars.Add(car);
            }

            string command = "";

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandArr = command.Split(" : ");
                string action = commandArr[0];
                string name = commandArr[1];

                if (action == "Drive")
                {
                    int distance = int.Parse(commandArr[2]);
                    int fuel = int.Parse(commandArr[3]);
                    Drive(name, distance, fuel, cars);
                } else if (action == "Refuel")
                {
                    int fuel = int.Parse(commandArr[2]);
                    Refuel(name, fuel, cars);
                } else if (action == "Revert")
                {
                    int kilometers = int.Parse(commandArr[2]);
                    Revert(name, kilometers, cars);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.name} -> Mileage: {car.mileage} kms, Fuel in the tank: {car.fuel} lt.");
            }
        }

        public static void Drive (string name, int distance, int fuel, List<Car> cars)
        {
            Car currentCar = cars.FirstOrDefault(x => x.name == name);

            if ((currentCar.mileage + distance) > 100000)
            {
                currentCar.mileage += distance;
                currentCar.fuel -= fuel;
                Console.WriteLine($"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                cars.Remove(currentCar);
                Console.WriteLine($"Time to sell the {name}!");
                return;
            }

            if (fuel > currentCar.fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
            } else if (currentCar.fuel > fuel)
            {
                currentCar.mileage += distance;
                currentCar.fuel -= fuel;
                Console.WriteLine($"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            }
        }

        public static void Refuel (string name, int fuel, List<Car> cars)
        {
            Car currentCar = cars.FirstOrDefault(x => x.name == name);

            if (currentCar.fuel + fuel > 75)
            {
                int amountRefueled = 75 - currentCar.fuel;
                currentCar.fuel = 75;
                Console.WriteLine($"{name} refueled with {amountRefueled} liters");
            } else
            {
                currentCar.fuel += fuel;
                Console.WriteLine($"{name} refueled with {fuel} liters");
            }
        }

        public static void Revert(string name, int kilometers, List<Car> cars)
        {
            Car currentCar = cars.FirstOrDefault(x => x.name == name);

            if ((currentCar.mileage - kilometers) < 10000)
            {
                currentCar.mileage = 10000;
            } else
            {
                currentCar.mileage -= kilometers;
                Console.WriteLine($"{name} mileage decreased by {kilometers} kilometers");
            }
        }
    }

    class Car
    {
        public Car (string name, int mileage, int fuel)
        {
            this.name = name;
            this.mileage = mileage;
            this.fuel = fuel;
        }

        public string name { get; set; }
        public int mileage { get; set; }
        public int fuel { get; set; }
    }
}