using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lettersPattern = @"[A-Za-z]+";
            string digitsPattern = @"\d+";
            string command = "";

            string[] validNames = Console.ReadLine().Split(", ");

            Regex regexLetters = new Regex(lettersPattern);
            Regex regexDigits = new Regex(digitsPattern);
            List<string> names = new List<string>();

            Dictionary<string, int> participants = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "end of race")
            {
                Match participantName = regexLetters.Match(command);
                Match participantDigits = regexDigits.Match(command);

                int currentDistance = 0;

                if (participantName.Success && participantDigits.Success)
                {
                    names.Add(participantName.Value);
                    string[] digits = participantDigits.Value.Split();
                    foreach (string digit in digits)
                    {
                        int currentDigit = int.Parse(digit);
                        currentDistance += currentDigit;
                    }
                }

            }
        }
    }
}