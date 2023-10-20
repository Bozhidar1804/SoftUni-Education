namespace _01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            double taxes = 0;
            double totalPrice = 0;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "special")
                {
                    if (totalPrice == 0)
                    {
                        Console.WriteLine("Invalid order!");
                        break;
                    } else
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
                        Console.WriteLine($"Taxes: {taxes:F2}$");
                        Console.WriteLine("-----------");
                        Console.WriteLine($"Total price: {((totalPrice + taxes) * 0.90):F2}$");
                        break;
                    }
                } else if (command == "regular") 
                {
                    if (totalPrice == 0)
                    {
                        Console.WriteLine("Invalid order!");
                        break;
                    } else
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
                        Console.WriteLine($"Taxes: {taxes:F2}$");
                        Console.WriteLine("-----------");
                        Console.WriteLine($"Total price: {(totalPrice + taxes):F2}$");
                        break;
                    }
                } else
                {
                    double currentPrice = double.Parse(command);
                    if (currentPrice <= 0)
                    {
                        Console.WriteLine("Invalid price!");
                        continue;
                    }
                    double currentTax = currentPrice / 5;
                    taxes += currentTax;
                    totalPrice += currentPrice;
                }

            }
        }
    }
}