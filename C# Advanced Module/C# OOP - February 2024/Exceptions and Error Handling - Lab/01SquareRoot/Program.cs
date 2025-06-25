namespace _01SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                double parsed = double.Parse(input);
                if (parsed < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(parsed));
            } catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            } finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}