namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Make = "BMW";
            car1.Model = "E46";
            car1.Year = 1999;

            Console.WriteLine($"Make: {car1.Make}, Model: {car1.Model}, Year: {car1.Year}");
        }
    }
}