namespace _01ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> money = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Queue<int> prices = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int foodCount = 0;

            while (money.Count > 0 && prices.Count > 0)
            {
                int moneyLast = money.Peek();
                int price = prices.Peek();

                if (moneyLast == price)
                {
                    money.Pop();
                    prices.Dequeue();
                    foodCount++;
                } else if (moneyLast > price)
                {
                    int change = moneyLast - price;
                    money.Pop();
                    if (money.Count > 0)
                    {
                        int previousMoney = money.Pop();
                        change += previousMoney;
                    }
                    money.Push(change);
                    prices.Dequeue();
                    foodCount++;
                } else if (moneyLast < price)
                {
                    money.Pop();
                    prices.Dequeue();
                }
            }

            if (foodCount >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
            } else if (foodCount > 0)
            {
                if (foodCount == 1)
                {
                    Console.WriteLine($"Henry ate: {foodCount} food.");
                } else
                {
                    Console.WriteLine($"Henry ate: {foodCount} foods.");
                }
            } else if  (foodCount == 0)
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}