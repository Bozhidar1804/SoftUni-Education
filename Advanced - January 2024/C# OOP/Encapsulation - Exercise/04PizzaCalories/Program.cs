using System.Xml.Linq;

namespace _04PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split(" ");
                Pizza pizza = new Pizza(pizzaInput[1]);

                string[] doughInput = Console.ReadLine().Split(" ");
                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                pizza.Dough = dough;

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split(" ");
                    try
                    {
                        string toppingType = tokens[1];
                        int toppingWeight = int.Parse(tokens[2]);
                        Topping topping = new Topping(toppingType, toppingWeight);
                        pizza.AddToppings(topping);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        return;
                    }
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            } catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}