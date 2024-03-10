namespace _04SumofIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            int sum = 0;

            foreach(string item in input)
            {
                try
                {
                    int num = int.Parse(item);
                    sum += num;

                } catch (FormatException fe)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                } catch (OverflowException oe)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }

                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}