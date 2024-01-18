namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                command = Console.ReadLine();
                if (command == "Revision")
                {
                    break;
                }

                string[] commandArr = command.Split(", ");
                string store = commandArr[0];
                string product = commandArr[1];
                double price = double.Parse(commandArr[2]);

                if (!stores.ContainsKey(store))
                {
                    stores.Add(store, new Dictionary<string, double>());
                    stores[store].Add(product, price);
                } else
                {
                    stores[store].Add(product, price);
                }
            }

            stores = stores.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var store in stores)
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}