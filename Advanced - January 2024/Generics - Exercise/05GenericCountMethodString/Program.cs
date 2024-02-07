namespace _05GenericCountMethodString;
public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Box<string> box = new Box<string>();
        for (int i = 0; i < n; i++)
        {
            string item = Console.ReadLine();
            box.Add(item);
        }

        string compareItem = Console.ReadLine();
        Console.WriteLine(box.Count(compareItem));
    }
}
