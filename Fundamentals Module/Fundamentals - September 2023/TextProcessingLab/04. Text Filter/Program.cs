namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string inputText = Console.ReadLine();
            string result = "";

            foreach (string word in bannedWords)
            {
                char asterisk = '*';
                int count = word.Length;

                string replacement = new string(asterisk, count);
                result = inputText.Replace(word, replacement);
                inputText = result;
            }
            Console.WriteLine(result);
        }
    }
}