namespace _09PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double sabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            /*int freeBelts = 0;
            int counting = 0;*/
            double sum = 0;

            /*for (int i = 0; i <= students; i++)
            {
                counting++;
                if (counting % 6 == 0)
                {
                    freeBelts++;
                }
            }*/

            double sabersTotal = Math.Ceiling(students * 1.1) * sabersPrice;
            double robesTotal = students * robesPrice;
            double beltsTotal = beltsPrice * (students - (students / 6));

            sum = sabersTotal + robesTotal + beltsTotal;

            if (sum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(sum - money):F2}lv more.");
            }
        }
    }
}