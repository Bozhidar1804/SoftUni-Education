namespace _07Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(" ");
            Tuple<string, string> firstLine = new Tuple<string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2]);

            string[] secondInput = Console.ReadLine().Split(" ");
            Tuple<string, int> secondLine = new Tuple<string, int>(secondInput[0], int.Parse(secondInput[1]));

            string[] thirdInput = Console.ReadLine().Split(" ");
            Tuple<int, double> thirdLine = new Tuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));

            Console.WriteLine(firstLine.ToString());
            Console.WriteLine(secondLine.ToString());
            Console.WriteLine(thirdLine.ToString());
        }
    }
}