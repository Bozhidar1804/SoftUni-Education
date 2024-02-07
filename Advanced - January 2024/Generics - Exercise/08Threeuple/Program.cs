namespace _08Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(" ");
            string townName = "";
            for (int i = 3; i < firstInput.Length; i++)
            {
                townName += firstInput[i] + " ";
            }
            Threeuple<string, string, string> firstLine = new Threeuple<string, string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2], townName);

            string[] secondInput = Console.ReadLine().Split(" ");
            bool IsDrunk = false;
            if (secondInput[2] == "drunk")
            {
                IsDrunk = true;
            } else if (secondInput[2] == "not")
            {
                IsDrunk = false;
            }
            Threeuple<string, int, bool> secondLine = new Threeuple<string, int, bool>(secondInput[0], int.Parse(secondInput[1]), IsDrunk);

            string[] thirdInput = Console.ReadLine().Split(" ");
            Threeuple<string, double, string> thirdLine = new Threeuple<string, double, string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);

            Console.WriteLine(firstLine.ToString());
            Console.WriteLine(secondLine.ToString());
            Console.WriteLine(thirdLine.ToString());
        }
    }
}