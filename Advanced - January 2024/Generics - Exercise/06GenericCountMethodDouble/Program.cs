namespace _06GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                double item = double.Parse(Console.ReadLine());
                box.Add(item);
            }
            double compareItem = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(compareItem));
        }
    }
}