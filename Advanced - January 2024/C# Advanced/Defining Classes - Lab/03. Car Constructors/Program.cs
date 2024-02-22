namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            Car car2 = new Car("BMW", "320", 2000);
            Car car3 = new Car("Mercedes", "G", 2016, 200, 200);

            Console.WriteLine($"{car1.Make}, {car1.Model}, {car1.Year}, {car1.FuelQuantity}, {car1.FuelQuantity}");
            Console.WriteLine($"{car2.Make}, {car2.Model}, {car2.Year}, {car2.FuelQuantity}");
            Console.WriteLine($"{car3.Make}, {car3.Model}, {car3.Year}, {car3.FuelQuantity}, {car3.FuelQuantity}");
        }
    }
}