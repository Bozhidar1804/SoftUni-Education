namespace _03PassedOrFailed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inputGrade = double.Parse(Console.ReadLine());

            if (inputGrade >= 3)
            {
                Console.WriteLine("Passed!");
            } else if (inputGrade < 3)
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}