namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArr = command.Split(", ");
                string direction = commandArr[0];
                string number = commandArr[1];

                if (direction == "IN")
                {
                    cars.Add(number);
                } else if (direction == "OUT")
                {
                    cars.Remove(number);
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine($"Parking Lot is Empty");
            } else if (cars.Count > 0)
            {
                foreach (string number in cars)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}