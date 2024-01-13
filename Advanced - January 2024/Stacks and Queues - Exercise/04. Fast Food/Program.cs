namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Count >= 0)
            {
                if (orders.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }

                int currentOrder = orders.Peek();
                if (totalFood - currentOrder > 0 || currentOrder == totalFood)
                {
                    orders.Dequeue();
                    totalFood -= currentOrder;
                } else if (currentOrder > totalFood)
                {
                    break;
                }
            }

            if (orders.Count > 0)
            {
                string result = "";
                while (orders.Count > 0)
                {
                    result += orders.Dequeue() + " ";
                }
                Console.WriteLine($"Orders left: {result}");
            }
        }
    }
}