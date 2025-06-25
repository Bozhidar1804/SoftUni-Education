namespace _01._Experience_Gaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int finalExp = int.Parse(Console.ReadLine());
            int battles = int.Parse(Console.ReadLine());
            int battleCount = 0;
            double totalExp = 0;

            while (battleCount < battles && totalExp < finalExp)
            {
                double currentExp = int.Parse(Console.ReadLine());
                battleCount++;

                if (battleCount % 3 == 0)
                {
                    totalExp = totalExp + (currentExp + (currentExp * 0.15));
                } else if (battleCount % 5 == 0)
                {
                    totalExp = totalExp + (currentExp - (currentExp * 0.10));
                } else if (battleCount % 15 == 0)
                {
                    totalExp = currentExp + (currentExp * 0.05);
                } else
                {
                    totalExp += currentExp;
                }


                if (totalExp >= finalExp)
                {
                    break;
                }
            }

            if (totalExp >= finalExp)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
            } else if (totalExp < finalExp)
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(finalExp - totalExp):F2} more needed.");
            }
        }
    }
}