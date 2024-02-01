namespace _06.SpeedRacing;
public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]), 0);

            cars.Add(car);
        }

        string command = "";
        while ((command = Console.ReadLine()) != "End")
        {
            string[] commandArr = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string carModel = commandArr[1];
            double distance = double.Parse(commandArr[2]);

            Car car = cars.FirstOrDefault(x => x.Model == carModel);
            car.Drive(carModel, distance, cars);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
        }
    }
}
