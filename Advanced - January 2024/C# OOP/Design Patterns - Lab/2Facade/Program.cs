namespace _2Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                .WithType("BMW")
                .WithColor("Black")
                .WithDoors(4)
                .Address
                .InCity("Yambol")
                .AtAddress("City Centre")
                .Build();
            Console.WriteLine(car.ToString());
        }
    }
}