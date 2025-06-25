namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            RandomList strings = new RandomList();
            Console.WriteLine(strings.RandomString(list));
        }
    }
}