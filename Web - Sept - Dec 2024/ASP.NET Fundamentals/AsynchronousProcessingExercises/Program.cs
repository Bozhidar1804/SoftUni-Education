namespace AsynchronousProcessingExercises
{
    public class Program
    {
        static void Main(string[] args)
        {
            //EvenNumbersThread();

            /* while (true)
            {
                string command = Console.ReadLine();
                if (command == "show")
                {
                    var result = SumAsync();
                    Console.WriteLine(result);
                }
            } */

            Chronometer chronometer = new Chronometer();

            string command;

            while ((command = Console.ReadLine()) != "exit")
            {
                if (command == "start")
                {
                    Task.Run(() =>
                    {
                        chronometer.Start();
                    });
                } else if (command == "stop")
                {
                    chronometer.Stop();
                } else if (command == "reset")
                {
                    chronometer.Reset();
                } else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                } else if (command == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("There are no laps recorded.");
                        return;
                    }

                    for (int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                    }
                } else if (command == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
            }

            chronometer.Stop();
        }

        private static long SumAsync()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            return Task.Run(() =>
            {
                long sum = 0;
                for (int i = start; i < end; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }
                return sum;
            }).Result;
        }


        private static void EvenNumbersThread()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            Thread evens = new Thread(() => PrintEvenNumbers(start, end));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work.");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
