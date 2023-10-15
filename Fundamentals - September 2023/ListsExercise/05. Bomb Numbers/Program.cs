using System.Diagnostics.CodeAnalysis;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bombInfo[0];
            int bombPower = bombInfo[1];

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == bombNumber)
                {
                    int start = i - bombPower;
                    if (start < 0)
                    {
                        start = 0;
                    }

                    int finish = i + bombPower + 1;
                    if (finish > sequence.Count)
                    {
                        finish = sequence.Count;
                    }

                    for (int j = start; j < finish; j++)
                    {
                        sequence.RemoveAt(start);
                    }
                    i--;
                }
            }
            Console.WriteLine(sequence.Sum());
        }
    }
}

/*
 for (int k = 1; k <= bombPower; ++k)
                    { if (i - 1 < 0)
                        {
                            continue; ;
                        } else
                        {
                            sequence.RemoveAt(i - 1);
                            i--;
                        }
                      if (i + 1 >= sequence.Count)
                        {
                            continue;
                        } else
                        {
                            sequence.RemoveAt(i + 1);
                        }
                    }
                    sequence.RemoveAt(i);
 */