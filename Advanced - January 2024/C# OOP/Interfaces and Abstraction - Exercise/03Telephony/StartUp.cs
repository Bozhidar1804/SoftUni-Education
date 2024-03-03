namespace _03Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");
            string[] urls = Console.ReadLine().Split(" ");
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.Call(number);
                } else if (number.Length == 10)
                {
                    smartphone.Call(number);
                }
            }

            foreach (string url in urls)
            {
                smartphone.Browse(url);
            }
        }
    }
}