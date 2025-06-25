namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string result = Repetitions(input, n);
            Console.WriteLine(result);
        }

        static string Repetitions(string text, int r)
        {
            string newText = "";
            for (int i = 0; i < r; i++)
            {
                newText += text;
            }
            return newText;
        }
    }
}