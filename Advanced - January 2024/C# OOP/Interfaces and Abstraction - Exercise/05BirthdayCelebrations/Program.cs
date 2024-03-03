namespace _05BirthdayCelebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BirthdayCheck birthdayCheck = new BirthdayCheck();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ');
                if (tokens[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    birthdayCheck.AddEntitiesForCheck(citizen);
                } else if (tokens[0] == "Pet")
                {
                    Pet pet = new Pet(tokens[1], tokens[2]);
                    birthdayCheck.AddEntitiesForCheck(pet);
                }
            }

            string validBirthdate = Console.ReadLine();
            Console.WriteLine(birthdayCheck.CheckIfBirthdateMatches(validBirthdate));
        }
    }
}