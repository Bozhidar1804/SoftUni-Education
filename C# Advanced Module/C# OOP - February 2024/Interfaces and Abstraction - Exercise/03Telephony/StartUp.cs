namespace _03Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");
            string[] urls = Console.ReadLine().Split(" ");

            foreach (string number in numbers)
            {
                if (IsNumberValid(number))
                {
                    ICall phone;

                    if (number.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }
                    else
                    {
                        phone = new Smartphone();
                    }

                    phone.Call(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (string url in urls)
            {
                IBrowse smartphone = new Smartphone();
                smartphone.Browse(url);
            }
        }

        public static bool IsNumberValid(string number)
        {
            return number.All(char.IsDigit);
        }
    }
}