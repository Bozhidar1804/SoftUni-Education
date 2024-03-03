using System.Text;

namespace _04BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            BorderControl borderControl = new BorderControl();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ");
                if (tokens.Length == 2)
                {
                    Robot robot = new Robot(tokens[0], tokens[1]);
                    borderControl.AddEntitiesForCheck(robot);
                } else if (tokens.Length == 3)
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    borderControl.AddEntitiesForCheck(citizen);
                }
            }

            string fakeId = Console.ReadLine();
            Console.WriteLine(borderControl.CheckWhichIdsAreFake(fakeId));
        }
    }
}