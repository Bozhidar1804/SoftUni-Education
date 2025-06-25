namespace _10RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double sum = 0;

            sum += headsetPrice * (lostGames / 2);
            sum += mousePrice * (lostGames / 3);
            sum += keyboardPrice * (lostGames / 6);
            sum += displayPrice * (lostGames / 12);
            Console.WriteLine($"Rage expenses: {sum:F2} lv.");

        }
    }
}