namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            Random rnd = new Random();
            for (int i = 0; i < input.Length - 1; i++)
            {
                int randomIndex = rnd.Next(input.Length);

                string currentWord = input[i];
                string randomWord = input[randomIndex];

                input[i] = randomWord;
                input[randomIndex] = currentWord;
            }

            foreach (string s in input)
            {
                Console.WriteLine(s);
            }
        }
    }
}