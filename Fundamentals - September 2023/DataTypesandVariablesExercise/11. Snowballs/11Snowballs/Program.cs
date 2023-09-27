namespace _11Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestSnowballValue = 0;
            double biggestSnowballSnow = 0;
            double biggestSnowballTime = 0;
            double biggestSnowballQuality = 0;

            for (int i = 0; i < n; i++)
            {
                double snowballSnow = int.Parse(Console.ReadLine());
                double snowballTime = int.Parse(Console.ReadLine());
                double snowballQuality = int.Parse(Console.ReadLine());

                double snowballValue = Math.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue > biggestSnowballValue)
                {
                    biggestSnowballValue = snowballValue;

                    biggestSnowballSnow = snowballSnow;
                    biggestSnowballTime = snowballTime;
                    biggestSnowballQuality = snowballQuality;
                }

            }

            Console.WriteLine($"{biggestSnowballSnow} : {biggestSnowballTime} = {biggestSnowballValue} ({biggestSnowballQuality})");
        }
    }
}