namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] inputArr = input.ToCharArray(); 

            Stack<char> letters = new Stack<char>();

            foreach (char c in inputArr)
            {
                letters.Push(c);
            }

            while (letters.Count != 0)
            {
                Console.Write(letters.Pop());
            }
        }
    }
}