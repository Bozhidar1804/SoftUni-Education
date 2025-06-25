namespace _12EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool a = true;

            while (a)
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    n = Math.Abs(n);
                }

                if (n % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");
                } else if (n % 2 == 0)
                {
                    Console.WriteLine($"The number is: {n}");
                    a = false;
                }
            }
        }
    }
}