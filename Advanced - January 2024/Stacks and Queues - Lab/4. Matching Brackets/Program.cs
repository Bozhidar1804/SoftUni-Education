namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] inputArr = input.ToCharArray();
            Stack<int> openBracketsIndexes = new Stack<int>();
            char openingBracket = '(';
            char closingBracket = ')';
            string output = "";

            for (int i = 0; i < inputArr.Length; i++)
            {
                char c = inputArr[i];

                if (c == openingBracket)
                {
                    openBracketsIndexes.Push(i);
                } else if (c == closingBracket)
                {
                    int start = openBracketsIndexes.Pop();
                    int end = i;

                    for (int j = start; j <= end; j++)
                    {
                        output += inputArr[j];
                    }
                    Console.WriteLine(output);
                    output = "";
                } 
            }
        }
    }
}