namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            List<Box> boxes = new List<Box>();
            string command = "";

            while (command != "end")
            {
                command = Console.ReadLine();
                if (command == "end") break;

                string[] input = command.Split(" ");

                int serialNumber = int.Parse(input[0]);
                string itemName = input[1];
                double itemQuantity = double.Parse(input[2]);
                double itemPrice = double.Parse(input[3]);

                Item item = new Item(itemName, itemPrice);
                items.Add(item);

                Box box = new Box(serialNumber, item, itemQuantity, itemQuantity * itemPrice);
                boxes.Add(box);
            }
            List<Box> descendedBoxes = boxes.OrderByDescending(b => b.PriceForBox).ToList();

            foreach (Box box in descendedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:F2}");
            }
        }
    }

    class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }
    }

    class Box
    {
        public Box(int serialNumber, Item item, double itemQuantity, double priceForBox)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            PriceForBox = priceForBox;
        }
        public int SerialNumber { get; set; }

        public Item Item { get; set; }

        public double ItemQuantity { get; set; }

        public double PriceForBox { get; set; }
    }
}