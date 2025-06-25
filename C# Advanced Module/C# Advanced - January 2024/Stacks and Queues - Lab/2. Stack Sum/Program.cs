namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> ints = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            string command = "";
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] splitted = command.Split(" ");
                string action = splitted[0].ToLower();
                if (action == "add")
                {
                    int num1 = int.Parse(splitted[1]);
                    int num2 = int.Parse(splitted[2]);
                    ints.Push(num1);
                    ints.Push(num2);
                } else if (action == "remove")
                {
                    int n = int.Parse(splitted[1]);
                    if (ints.Count < n)
                    {
                        continue;
                    } else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            ints.Pop();
                        }
                    }
                }
            }

            int sum = 0;

            while (ints.Count != 0)
            {
                sum += ints.Pop();
            }
            Console.WriteLine($"Sum: {sum}");

            //Or Console.WriteLine(ints.Sum());
        }
    }
}