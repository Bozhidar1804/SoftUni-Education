namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodKg = double.Parse(Console.ReadLine());
            double food = foodKg * 1000;
            double hayKg = double.Parse(Console.ReadLine());
            double hay = hayKg * 1000;
            double coverKg = double.Parse(Console.ReadLine());
            double cover = coverKg * 1000;
            double weightKg = double.Parse((Console.ReadLine()));
            double weight = weightKg * 1000;

            double hayGiven = 0;
            double coverGiven = 0;

            for (int i = 1; i <= 30; i++)
            {
                food -= 300;
                if (i % 2 == 0)
                {
                    hayGiven = food * 0.05;
                    hay -= hayGiven;
                }
                
                if (i % 3 == 0)
                {
                    coverGiven = weight / 3;
                    cover -= coverGiven;
                }

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                } 
            }

            if (food >= 0 && hay >= 0 && cover >= 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(food / 1000):F2}, Hay: {(hay / 1000):F2}, Cover: {(cover / 1000):F2}.");
            }
        }
    }
}