namespace _08BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            string biggestKeg = "";
            double biggestKegSize = 0;

            while (counter <= n)
            {
                string currentKeg = Console.ReadLine();
                float currentRadius = float.Parse(Console.ReadLine());
                int currentHeight = int.Parse(Console.ReadLine());

                double currentSize = Math.PI * (currentRadius * currentRadius) * currentHeight;
                
                if (currentSize > biggestKegSize)
                {
                    biggestKeg = currentKeg;
                    biggestKegSize = currentSize;
                }



                counter++;
            }
            Console.WriteLine(biggestKeg);
        }
    }
}