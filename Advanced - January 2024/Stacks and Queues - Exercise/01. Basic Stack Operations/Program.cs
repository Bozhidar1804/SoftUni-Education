using System.Security;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> ints = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int n = input[0];
            int s = input[1];
            int x = input[2];

            bool xExists = false;

            for (int i = 0; i < s; i++)
            {
                ints.Pop();
            }

            if (ints.Contains(x))
            {
                xExists = true;
            }

            if (xExists)
            {
                Console.WriteLine("true");
            } else if (ints.Count == 0)
            {
                Console.WriteLine(0);
            } else
            {
                int smallestNumber = 0;
                while (ints.Count != 0)
                {
                    int currentNumber1 = ints.Pop();
                    if (ints.Count == 0)
                    {
                        if (currentNumber1 < smallestNumber)
                        {
                            smallestNumber = currentNumber1;
                        }
                        break;
                    }

                    if (currentNumber1 < smallestNumber)
                    {
                        smallestNumber = currentNumber1;
                    }

                    int currentNumber2 = ints.Pop();
                    if (ints.Count == 0)
                    {
                        if (currentNumber2 < smallestNumber)
                        {
                            smallestNumber = currentNumber2;
                        }
                        break;
                    }

                    if (currentNumber1 < currentNumber2)
                    {
                        smallestNumber = currentNumber1;
                    }
                    else
                    {
                        smallestNumber = currentNumber2;
                    }
                }
                Console.WriteLine(smallestNumber);
            }


        }
    }
}