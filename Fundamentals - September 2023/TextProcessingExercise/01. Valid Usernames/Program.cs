namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            List<string> result = new List<string>();

            foreach(string s in input)
            {
                if (s.Length > 3 && s.Length < 16)
                {
                    bool validWord = true;
                    foreach (char c in s)
                    {
                        if (!char.IsLetterOrDigit(c) && !(c == '-' || c == '_'))
                        {
                            validWord = false;
                            break;
                        }
                    }
                    if (validWord)
                    {
                        result.Add(s);
                    }
                }
            }

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}