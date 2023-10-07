namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double result = CalculateRectangleArea(width, height);
            Console.WriteLine(result);
        }

        private static double CalculateRectangleArea(double w, double h)
        {
            double result = w * h;
            return result;
        }
    }
}