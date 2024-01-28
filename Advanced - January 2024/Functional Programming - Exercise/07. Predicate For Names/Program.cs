namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>, Predicate<string>> FilterNames = (names, match) =>
            {
                foreach (string name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };
            
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ").ToList();

            FilterNames(names, n => n.Length <= length);
        }
    }
}