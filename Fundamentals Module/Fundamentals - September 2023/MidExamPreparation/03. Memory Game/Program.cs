using System.Security.Cryptography;

namespace _03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine().Split(' ').ToList();
            string command = "";
            int moves = 0;

            while (command != "end")
            {
                command = Console.ReadLine();
                if (command == "end" && sequence.Count > 0)
                {
                    Console.WriteLine("Sorry you lose :(");
                    Console.WriteLine(string.Join(' ', sequence));
                    break;
                } else if (sequence.Count == 0 && command != "end")
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    continue;
                } else if (sequence.Count == 0 && command == "end")
                {
                    break;
                }

                int[] input = command.Split(' ').Select(int.Parse).ToArray();
                int index = input[0];
                int index2 = input[1];
                moves++;

                if ((index < 0 || index >= sequence.Count) || (index2 < 0 || index2 >= sequence.Count) || index == index2)
                {
                    string newSymbols = $"-{moves}a";
                    List<string> newElements = new List<string> { newSymbols, newSymbols };
                    int middleRange = sequence.Count / 2;
                    sequence.InsertRange(middleRange, newElements);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                } else
                {
                    if (sequence[index] == sequence[index2])
                    {
                        string matchingElements = sequence[index];
                        Console.WriteLine($"Congrats! You have found matching elements - {matchingElements}!");
                        int checkIndex = index;
                        int checkIndex2 = index2;
                        if (checkIndex == checkIndex2++ || checkIndex2 == checkIndex++)
                        {
                            sequence.RemoveAt(index);
                            sequence.RemoveAt(index2);
                        } else
                        {
                            sequence.RemoveAt(index);
                            sequence.RemoveAt(index2 - 1);
                        }
                    } else if (sequence[index] != sequence[index2])
                    {
                        Console.WriteLine("Try again!");
                    }
                }
            }
        }
    }
}