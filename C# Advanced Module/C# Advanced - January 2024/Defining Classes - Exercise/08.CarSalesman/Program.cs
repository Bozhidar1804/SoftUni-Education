using System.Text;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 2)
                {
                    Engine engine = new Engine(input[0], int.Parse(input[1]));
                    engines.Add(engine);
                } else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int displacement))
                    {
                        Engine engine = new Engine(input[0], int.Parse(input[1]), displacement);
                        engines.Add(engine);
                    } else
                    {
                        Engine engine = new Engine(input[0], int.Parse(input[1]), input[2]);
                        engines.Add(engine);
                    }
                } else if (input.Length == 4)
                {
                    Engine engine = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]);
                    engines.Add(engine);
                }
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 2)
                {
                    if (engines.Exists(e => e.Model == input[1]))
                    {
                        Engine engine = engines.Where(e => e.Model == input[1]).First();
                        Car car = new Car(input[0], engine);
                        cars.Add(car);
                    }
                } else if (input.Length == 3)
                {
                    Engine engine = engines.Where(e => e.Model == input[1]).First();

                    if (int.TryParse(input[2], out int weight))
                    {
                        Car car = new Car(input[0], engine, weight);
                        cars.Add(car);
                    } else
                    {
                        string color = input[2];
                        Car car = new Car(input[0], engine, color);
                        cars.Add(car);
                    }
                } else if (input.Length == 4)
                {
                    Engine engine = engines.Where(e => e.Model == input[1]).First();

                    Car car = new Car(input[0], engine, int.Parse(input[2]), input[3]);
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}