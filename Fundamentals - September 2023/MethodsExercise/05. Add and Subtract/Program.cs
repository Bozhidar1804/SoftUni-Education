namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = Subtract(Sum(firstNum, secondNum), thirdNum);
            Console.WriteLine(result);
        }

        private static int Sum(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}