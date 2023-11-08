namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string resultDigits = "";
            string resultLetters = "";
            string resultOthers = "";

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    resultDigits += c;
                } else if (char.IsLetter(c))
                {
                    resultLetters += c;
                } else
                {
                    resultOthers += c;
                }
            }

            Console.WriteLine(resultDigits);
            Console.WriteLine(resultLetters);
            Console.WriteLine(resultOthers);
        }
    }
}