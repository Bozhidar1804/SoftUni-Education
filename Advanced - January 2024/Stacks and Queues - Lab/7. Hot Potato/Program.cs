namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>(Console.ReadLine().Split());
            Queue<string> backupPeople = new Queue<string>();
            int n = int.Parse(Console.ReadLine());

            while (people.Count != 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == n)
                    {
                        Console.WriteLine($"Removed {people.Dequeue()}");
                    } else if (n > 1)
                    {
                        string currentRemoved = people.Dequeue();
                        people.Enqueue(currentRemoved);
                    } else
                    {

                    }
                }
            }

            Console.WriteLine($"Last is {people.Dequeue()}");
        }
    }
}