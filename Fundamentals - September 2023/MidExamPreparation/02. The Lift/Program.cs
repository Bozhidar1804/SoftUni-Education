namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int queue = int.Parse(Console.ReadLine());
            int[] liftState = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int wagons = liftState.Length;
            int index = 0;

            while(!WagonsFull(liftState, wagons, queue))
            {
                for (int j = liftState[index]; j < 4; j++)
                {
                    liftState[index] += 1;
                    queue--;
                    if (queue == 0)
                    {
                       break;
                    }
                }

                index++;
            }

            if (queue > 0)
            {
                Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
                foreach (int i in liftState)
                {
                    Console.Write($"{i} ");
                }
            } else if (queue == 0 || queue < 0)
            {
                Console.WriteLine("The lift has empty spots!");
                foreach (int i in liftState)
                {
                    Console.Write($"{i} ");
                }
            }
        }

        private static bool WagonsFull(int[] liftState, int wagons, int queue)
        {
            if (queue == 0)
            {
                return true;
            }
            bool result = true; ;
            for (int i = 0; i < wagons; i++)
            {
                if (liftState[i] != 4)
                {
                    result = false;
                    return result;
                }
            }

            return result;
        }
    }
}