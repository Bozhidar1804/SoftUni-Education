 namespace _05Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            bool passed = true;
            string currentGuess = "";
            int wrongGuesses = 0;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            while (passed)
            {
                currentGuess = Console.ReadLine();

                if (currentGuess == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    passed = false;
                } else if (currentGuess != username)
                {
                    wrongGuesses++;
                    if (wrongGuesses >= 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        passed = false;
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}