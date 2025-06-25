namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList(); // 1 2 3 4 5
            numbers = Gauss(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> Gauss(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                numbers[i] = numbers[i] + numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
            }
            return numbers;
        }
    }
}