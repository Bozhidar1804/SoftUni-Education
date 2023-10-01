namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] topIntegers = new int[input.Length];
            bool a = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    topIntegers[i] = input[i];
                    break;
                }

                if (i == 0 && input[i] > input[i + 1])
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (input[i] > input[j])
                        {

                        }else if (input[i] < input[j])
                        {
                            a = false;
                        }
                    }
                    if (a)
                    {
                        topIntegers[i] = input[i];
                    }
                    continue;
                }

                if (input[i] > input[i + 1])
                {
                    for (int j = i; j < input.Length; j++)
                    {
                        if (input[i] > input[j])
                        {

                        } else if (input[i] < input[j] || (input[i] == input[j] && i != j))
                        {
                            a = false;
                        }
                    }
                    if (a)
                    {
                        topIntegers[i] = input[i];
                    }
                }
                a = true;
            }

            for (int i = 0; i < topIntegers.Length; i++)
            {
                if (i != topIntegers.Length - 1 && topIntegers[i] == 0)
                {
                    continue;
                }
                Console.Write($"{topIntegers[i]} ");
            }
        }
    }
}