namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool runningProgram = true;
            while(runningProgram)
            {
                string currentInput = Console.ReadLine();
                if (currentInput == "END")
                {
                    runningProgram = false;
                    continue;
                }

                IsPalindromeInt(currentInput);
            }
        }

        private static bool IsPalindromeInt(string input)
        {
            bool result = false;
            char[] inputArray = input.ToCharArray();
            Array.Reverse(inputArray);
            string reversed = new string(inputArray);

            if (input == reversed)
            {
                result = true;
                Console.WriteLine("true");
                return result;
            }
            Console.WriteLine("false");
            return result;
        }
    }
}