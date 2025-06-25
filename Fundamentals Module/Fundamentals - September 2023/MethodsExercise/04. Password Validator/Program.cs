namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool invalidPassword = true;

            while(invalidPassword)
            {
                string input = Console.ReadLine();
                if (IsPassValid(input))
                {
                    invalidPassword = false;
                    Console.WriteLine("Password is valid");
                }
            }
        }

        private static bool IsPassValid(string input)
        {
            bool result = true;
            if (!CharactersRange(input))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                result = false;
            }
            if (!IsOnlyLettersAndDigits(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                result = false;
            }
            if (!HasTwoDigits(input))
            {
                Console.WriteLine("Password must have at least 2 digits");
                result = false;
            }
            return result;
        }

        private static bool CharactersRange(string s)
        {
            int charactersCount = 0;
            bool result = true;
            foreach (char c in s)
            {
                charactersCount++;
            }
            if (charactersCount < 6 || charactersCount > 10)
            {
                result = false;
                return result;
            }
            return result;
        }

        private static bool IsOnlyLettersAndDigits(string s)
        {
            foreach(char c in s)
            {
                if(!Char.IsLetter(c) && !Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool HasTwoDigits(string s)
        {
            int digitsCount = 0;
            bool result = false;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    digitsCount++;
                }
            }
            if (digitsCount >= 2)
            {
                result = true;
                return result;
            }
            return result;
        }
    }
}