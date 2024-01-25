namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> checker = word => char.IsUpper(word[0]);

            words = words.Where(w => checker(w)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}