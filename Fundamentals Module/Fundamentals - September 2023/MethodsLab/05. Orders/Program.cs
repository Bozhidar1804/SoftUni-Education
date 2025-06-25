namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double priceCoffee = 1.50;
            double priceWater = 1.00;
            double priceCoke = 1.40;
            double priceSnacks = 2.00;
            double currentPrice = 0;

            if (product == "coffee")
            {
                currentPrice = priceCoffee;
            } else if (product == "water")
            {
                currentPrice = priceWater;
            } else if (product == "coke")
            {
                currentPrice = priceCoke;
            } else if (product == "snacks")
            {
                currentPrice = priceSnacks;
            }

            double result = PriceOfOrder(currentPrice, quantity);
            Console.WriteLine($"{result:F2}");
        }

        private static double PriceOfOrder(double currentPrice, int quantity)
        {
            double result = currentPrice * quantity;
            return result;
        }
    }
}