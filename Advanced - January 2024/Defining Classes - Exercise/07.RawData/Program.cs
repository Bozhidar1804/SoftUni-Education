namespace _07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                Car car = new Car(input[0], int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]), input[4],
                    float.Parse(input[5]), int.Parse(input[6]),
                    float.Parse(input[7]), int.Parse(input[8]),
                    float.Parse(input[9]), int.Parse(input[10]),
                    float.Parse(input[11]), int.Parse(input[12]));
                cars.Add(car);
            }

            string type = Console.ReadLine();
            if (type == "fragile")
            {
                foreach (Car car in cars.Where(c => c.Cargo.Type == "fragile"))
                {
                    bool validTire = false;
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            validTire = true;
                            continue;
                        }
                    }
                    if (validTire)
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            } else if (type == "flammable")
            {
                foreach (Car car in cars.Where(c => c.Cargo.Type == "flammable"))
                {
                    if (car.Engine.Power > 250)
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }
        }
    }
}