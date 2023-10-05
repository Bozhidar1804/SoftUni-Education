namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            string[] currentPair = new string[2];
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    continue;
                }

                for (int k = 0; k < input.Length; k++)
                {
                    if (input[i] + input[k] == n)
                    {
                        if (result.Contains(input[i].ToString()))
                        {
                            break;
                        }
                        string firstChar = input[i].ToString();
                        string secondChar = input[k].ToString();
                        currentPair[0] = firstChar;
                        currentPair[1] = secondChar;
                        result[i] = currentPair[0] + " " + currentPair[1];
                    }
                }
            }

            foreach(string s in result)
            {
                Console.Write($"{s} ");
            }
        }
    }
}