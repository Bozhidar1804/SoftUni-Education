using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\#{1}|\@{1})(?<word1>[A-Za-z]{3,})(\1{2})(?<word2>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            Dictionary<string, string> resultPairs = new Dictionary<string, string>();
            Dictionary<string, string> resultMirrors = new Dictionary<string, string>();

            foreach (Match match in matches)
            {
                string word1 = match.Groups["word1"].Value;
                string word2 = match.Groups["word2"].Value;
                resultPairs.Add(word1, word2);

                if (isMirrors(word1, word2))
                {
                    resultMirrors.Add(word1, word2);
                }
            }

            
            if (resultPairs.Count == 0 && resultMirrors.Count == 0) 
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            } else if (resultPairs.Count > 0 && resultMirrors.Count == 0)
            {
                Console.WriteLine($"{resultPairs.Count} word pairs found!");
                Console.WriteLine("No mirror words!");
            }  else if (resultPairs.Count > 0 && resultMirrors.Count > 0)
            {
                Console.WriteLine($"{resultPairs.Count} word pairs found!");
                Console.WriteLine("The mirror words are:");
                StringBuilder result = new StringBuilder();
                int addedMirrors = 0;
                foreach (KeyValuePair<string, string> mirror in resultMirrors)
                {
                    result.Append(mirror.Key + " <=> " + mirror.Value);
                    addedMirrors++;

                    if (!(addedMirrors == resultMirrors.Count))
                    {
                        result.Append(", ");
                    }
                }
                Console.WriteLine(result);
            }
        }

        public static bool isMirrors(string word1, string word2)
        {
            bool result = false;

            char[] word1Array = word1.ToCharArray();
            Array.Reverse(word1Array);
            string reversedStr1 = new string(word1Array);

            if (reversedStr1 == word2)
            {
                result = true;
            }

            return result;
        }
    }
}