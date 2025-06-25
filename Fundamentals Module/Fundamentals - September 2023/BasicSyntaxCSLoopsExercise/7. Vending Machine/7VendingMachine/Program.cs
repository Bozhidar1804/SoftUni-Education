namespace _7VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            double inputCoins = 0; 
            double sum = 0;

            while (command != "Start")
            {
                command = Console.ReadLine();
                if (command == "Start")
                {
                    break;
                } else
                {
                    inputCoins = double.Parse(command);
                    if (inputCoins == 0.1 || inputCoins == 0.2 || inputCoins == 0.5 || inputCoins == 1 || inputCoins == 2)
                    {
                        sum += inputCoins;
                    }
                    else
                    {
                        Console.WriteLine($"Cannot accept {inputCoins}");
                    }
                }
            }
            string currentProduct = "";

            while (command != "End")
            {
                command = Console.ReadLine();
                double priceNuts = 2;
                double priceWater = 0.7;
                double priceCrisps = 1.5;
                double priceSoda = 0.8;
                double priceCoke = 1;

                if (command == "End")
                {
                    break;
                }
                currentProduct = command;
                if (currentProduct == "Nuts")
                {
                    if (sum >= priceNuts)
                    {
                        sum -= priceNuts;
                        Console.WriteLine("Purchased nuts");
                    } else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                } else if (currentProduct == "Water")
                {
                    if (sum >= priceWater)
                    {
                        sum -= priceWater;
                        Console.WriteLine("Purchased water");
                    } else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                } else if (currentProduct == "Crisps")
                {
                    if (sum >= priceCrisps)
                    {
                        sum -= priceCrisps;
                        Console.WriteLine("Purchased crisps");
                    } else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                } else if (currentProduct == "Soda")
                {
                    if (sum >= priceSoda)
                    {
                        sum -= priceSoda;
                        Console.WriteLine("Purchased soda");
                    } else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                } else if (currentProduct == "Coke")
                {
                    if (sum >= priceCoke)
                    {
                        sum -= priceCoke;
                        Console.WriteLine("Purchased coke");
                    } else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                } else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {sum:F2}");

        }
    }
}