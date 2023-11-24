using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }


                string[] partsCommand = command.Split();

                string firstElementCommand = partsCommand[0];


                if (firstElementCommand == "Add")
                {
                    int number = int.Parse(partsCommand[1]);
                    numbers.Add(number);
                }

                else if (firstElementCommand == "Insert")
                {
                    int number = int.Parse(partsCommand[1]);
                    int index = int.Parse(partsCommand[2]);

                    if (!IsValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }

                else if (firstElementCommand == "Remove")
                {
                    int index = int.Parse(partsCommand[1]);

                    if (!IsValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(index);
                }

                else if (firstElementCommand == "Shift")
                {
                    string secondElementCommand = partsCommand[1];
                    int count = int.Parse(partsCommand[2]);
                    {
                        if (secondElementCommand == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int firstNumberInNummbers = numbers[0];
                                numbers.RemoveAt(0);
                                numbers.Add(firstNumberInNummbers);
                            }
                        }

                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int lastNumberInNumbers = numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);
                                numbers.Insert(0, lastNumberInNumbers);
                            }
                        }
                    }
                }



            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool IsValid(int index, List<int> numbers)
        {
            return index >= 0 && index < numbers.Count;
        }
    }
}