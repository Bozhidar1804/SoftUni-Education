namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Advertisement ad = new Advertisement();
            ad.Phrases = new[] { "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product." };

            ad.Events = new[] {"Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            ad.Authors = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            ad.Cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] output = new string[4];
                output = GenerateAd(ad.Phrases, ad.Events, ad.Authors, ad.Cities);
                foreach(string s in output)
                {
                    Console.Write($"{s} ");
                }

            }
        }

        public static string[] GenerateAd(string[] phrases, string[] events, string[] authors, string[] cities)
        {
            string[] returnValue = new string[4];
            Random random = new Random();
            returnValue[0] = phrases[random.Next(0, phrases.Length - 1)];
            returnValue[1] = events[random.Next(0, events.Length - 1)];
            returnValue[2] = authors[random.Next(0, authors.Length - 1)] + " - ";
            returnValue[3] = cities[random.Next(0, cities.Length - 1)] + ".";

            return returnValue;
        }
    }

    class Advertisement
    {
        public string[] Phrases;

        public string[] Events;

        public string[] Authors;

        public string[] Cities;
    }
}