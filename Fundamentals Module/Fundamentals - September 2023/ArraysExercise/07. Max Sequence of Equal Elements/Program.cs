namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string sequence = "";
            string longestSequence = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    break;
                }

                if (input[i] == input[i + 1])
                {
                    for (int k = i; input[i] == input[k]; k++)
                    {
                        sequence += input[k] + " ";
                        if (sequence.Length > longestSequence.Length)
                        {
                            longestSequence = sequence;
                        }

                        if (k == input.Length - 1)
                        {
                            break;
                        }
                    }
                }
                sequence = "";
            }

            string[] output = longestSequence.Split();
            foreach(string s in output)
            {
                Console.Write($"{s} ");
            }

        }
    }
}