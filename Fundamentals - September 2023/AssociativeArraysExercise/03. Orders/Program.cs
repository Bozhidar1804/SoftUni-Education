namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string command = "";

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] commandArr = command.Split(" ");
                string name = commandArr[0];
                double price = double.Parse(commandArr[1]);
                double quantity = double.Parse(commandArr[2]);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, new Product(name, price, quantity));
                } else
                {
                    products[name].Update(price, quantity);
                }
            }

            foreach (KeyValuePair<string, Product> kvp in products)
            {
                Console.WriteLine($"{kvp.Key} -> {(kvp.Value.GetTotal):F2}");
            }
        }
    }

    class Product
    {
        public Product (string name, double price, double quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Update (double price, double quantity)
        {
            Price = price;
            Quantity += quantity;
        }

        public double GetTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
        public string Name { get; set; }

        public double Price { get; set; } 

        public double Quantity { get; set; }
    }
}