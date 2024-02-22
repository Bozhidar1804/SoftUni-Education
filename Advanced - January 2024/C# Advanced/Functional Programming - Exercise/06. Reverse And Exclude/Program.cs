namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, string> FormatOutput = (numbers) =>
            {
                string output = "";
                foreach (int n in numbers)
                {
                    output += $"{n} ";
                }
                return output;
            };

            Func<List<int>, List<int>> ReverseList = (numbers) =>
            {
                List<int> result = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    result.Add(numbers[i]);
                }

                return result;

            };

            Func<List<int>, int, List<int>> Exclude = (numbers, divisibleNumber) =>
            {
                List<int> result = new List<int>();

                foreach (int number in numbers)
                {
                    if (number % divisibleNumber == 0)
                    {
                        continue;
                    } else
                    {
                        result.Add(number);
                    }
                }

                return result;
            };

            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int divisibleNumber = int.Parse(Console.ReadLine());

            List<int> result = Exclude(numbers, divisibleNumber);
            result = ReverseList(result);
            Console.WriteLine(FormatOutput(result));
        }
    }
}