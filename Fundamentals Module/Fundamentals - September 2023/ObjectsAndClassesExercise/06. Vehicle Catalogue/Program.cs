namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string command = "";

            while (command != "End")
            {
                command = Console.ReadLine();
                if (command == "End") break;

                string[] commandArr = command.Split(" ");
                Vehicle vehicle = new Vehicle(commandArr[0], commandArr[1], commandArr[2], int.Parse(commandArr[3]));
                vehicles.Add(vehicle);
            }

            string input = "";
            while (input != "Close the Catalogue")
            {
                input = Console.ReadLine();
                if (input == "Close the Catalogue") break;


                string currentModel = input;
                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.Model == currentModel)
                    {
                        Console.WriteLine($"Type: {FirstCharToUpper(vehicle.Type)}");
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                    }
                }
            }


            double averageHpCars = 0;
            int carsCount = 0;

            double averageHpTrucks = 0;
            int trucksCount = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Type == "car")
                {
                    averageHpCars += vehicle.Horsepower;
                    carsCount++;
                } else if (vehicle.Type == "truck")
                {
                    averageHpTrucks += vehicle.Horsepower;
                    trucksCount++;
                }
            }

            if (carsCount > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(averageHpCars / carsCount):F2}.");
            }
            else if (carsCount == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucksCount > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(averageHpTrucks / trucksCount):F2}.");
            } else if (trucksCount == 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }


        }

        public static string FirstCharToUpper(string input)
        {
            string returnValue = char.ToUpper(input[0]) + input.Substring(1);
            return returnValue;

        }
    }

    class Vehicle
    {
        public Vehicle (string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }
    }
}