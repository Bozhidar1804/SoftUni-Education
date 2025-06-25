namespace _01IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1 = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());
            int input3 = int.Parse(Console.ReadLine());
            int input4 = int.Parse(Console.ReadLine());
            int result = 0;

            result = input1 + input2;
            result /= input3;
            result *= input4;

            Console.WriteLine(result);

        }
    }
}