namespace _04Backin30min
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int minutes2 = minutes + 30;


            if (minutes2 >= 60)
            {
                minutes2 = minutes2 - 60;
                hours++;
                if (hours >= 24)
                {
                    hours = 0;
                }
                if (minutes2 < 10)
                {
                    Console.WriteLine($"{hours}:0{minutes2}");
                } else
                {
                    Console.WriteLine($"{hours}:{minutes2}");
                }
            } else if (minutes2 < 60 || minutes2 >= 10)
            {
                Console.WriteLine($"{hours}:{minutes2}");
            }
        }
    }
}