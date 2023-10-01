namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            bool indexExists = false;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < i; j ++)
                {
                    leftSum += input[j];
                }

                for (int k = i + 1; k < input.Length; k++)
                {
                    rightSum += input[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    indexExists = true;
                } else
                {
                    leftSum = 0;
                    rightSum = 0;
                }
            }

            if (!indexExists)
            {
                Console.WriteLine("no");
            }
        }
    }
}