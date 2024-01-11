namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = "";
            Queue<string> traffic = new Queue<string>();
            int dequeuedCars = 0;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "end")
                {
                    break;
                }

                if (command != "green")
                {
                    traffic.Enqueue(command);
                } else if (command == "green")
                {
                    for (int i = 0; i < n && traffic.Count > 0; i++)
                    {
                        Console.WriteLine($"{traffic.Dequeue()} passed!");
                        dequeuedCars++;
                    }
                    continue;
                }

                while ((command = Console.ReadLine()) != "green")
                {
                    if (command == "end")
                    {
                        break;
                    }
                    traffic.Enqueue(command);
                }

                if (command == "end")
                {
                    break;
                }

                for (int i = 0; i < n && traffic.Count > 0; i++)
                {
                    Console.WriteLine($"{traffic.Dequeue()} passed!");
                    dequeuedCars++;
                }
            }

            Console.WriteLine($"{dequeuedCars} cars passed the crossroads.");
        }
    }
}