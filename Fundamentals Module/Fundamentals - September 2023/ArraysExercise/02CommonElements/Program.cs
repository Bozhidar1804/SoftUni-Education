namespace _02CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split(" ");
            string[] secondArr = Console.ReadLine().Split(" ");

            string result = "";

            foreach(string s in secondArr)
            {
                if(firstArr.Contains(s))
                {
                    result += s;
                    result += " ";
                }
            }

            Console.WriteLine(result);
        }
    }
}