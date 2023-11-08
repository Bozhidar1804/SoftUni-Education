namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstStr = Console.ReadLine();
            string secondStr = Console.ReadLine();
            string result = "";

            while (secondStr.Contains(firstStr))
            {
                int length = firstStr.Length;
                int index = secondStr.IndexOf(firstStr, 0);

                result = secondStr.Remove(index, length);
                secondStr = result;
            }

            Console.WriteLine(result);
        }
    }
}