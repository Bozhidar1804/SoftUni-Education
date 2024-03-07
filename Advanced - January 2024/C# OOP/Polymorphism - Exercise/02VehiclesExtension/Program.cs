using _02VehiclesExtension;

namespace _01Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ");
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(" ");
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split(" ");
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] command = Console.ReadLine().Split(" ");

                    if (command[0] == "Drive")
                    {
                        switch (command[1])
                        {
                            case "Car":
                                car.Drive(double.Parse(command[2]));
                                break;
                            case "Truck":
                                truck.Drive(double.Parse(command[2]));
                                break;
                            case "Bus":
                                bus.DriveWithPeople(double.Parse(command[2]));
                                break;
                        }
                    }
                    else if (command[0] == "Refuel")
                    {
                        switch (command[1])
                        {
                            case "Car":
                                car.Refuel(double.Parse(command[2]));
                                break;
                            case "Truck":
                                truck.Refuel(double.Parse(command[2]));
                                break;
                            case "Bus":
                                bus.Refuel(double.Parse(command[2]));
                                break;
                        }
                    }
                    else if (command[0] == "DriveEmpty")
                    {
                        if (command[1] == "Bus")
                        {
                            bus.Drive(double.Parse(command[2]));
                        }
                    }
                } catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}