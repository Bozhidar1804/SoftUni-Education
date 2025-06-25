namespace _03Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] currentNumbers = new int[2];
                string[] currentInput = Console.ReadLine().Split(" ");
                currentNumbers[0] = int.Parse(currentInput[0]);
                currentNumbers[1] = int.Parse(currentInput[1]);

                if (i % 2 != 0)
                {
                    firstArr[i] = currentNumbers[0];
                    secondArr[i] = currentNumbers[1];
                } else if (i % 2 == 0)
                {
                    firstArr[i] = currentNumbers[1];
                    secondArr[i] = currentNumbers[0];
                }
            }

            foreach (int num in secondArr)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();

            foreach (int num in firstArr)
            {
                Console.Write($"{num} ");
            }
        }
    }
}