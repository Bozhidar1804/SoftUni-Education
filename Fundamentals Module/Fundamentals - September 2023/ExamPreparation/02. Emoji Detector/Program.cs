using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string validEmojiPattern = @"(\*{2}|\:{2})(?<Emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";
            string input = Console.ReadLine();
            
            Regex regexEmojis = new Regex(validEmojiPattern);
            MatchCollection emojiMatches = regexEmojis.Matches(input);
            Regex regexDigits = new Regex(digitsPattern);
            MatchCollection digitsMatches = regexDigits.Matches(input);

            ulong coolSum = 1;

            foreach (Match match in digitsMatches)
            {
                coolSum *= ulong.Parse(match.Value);
            }

            Console.WriteLine($"Cool threshold: {coolSum}");

            List<string> coolEmojis = new List<string>();
            int validEmojisCount = 0;
            foreach (Match match in emojiMatches)
            {
                string emojiName = match.Groups["Emoji"].Value;
                ulong valuesSum = 0;
                foreach (char c in emojiName)
                {
                    valuesSum += c;
                }

                if (valuesSum > coolSum)
                {
                    coolEmojis.Add(match.ToString());
                }
                validEmojisCount++;
            }

            Console.WriteLine($"{validEmojisCount} emojis found in the text. The cool ones are:");
            foreach (string coolEmoji in coolEmojis)
            {
                Console.WriteLine($"{coolEmoji}");
            }
        }
    }
}