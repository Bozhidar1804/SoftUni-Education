namespace Project_R_P_S
{
    internal class RockPaperScissors
    {
        static void Main(string[] args)
        {
            const string Rock = "Rock";
            const string Paper = "Paper";
            const string Scissors = "Scissors";

            Console.Write("Choose [r]ock, [p]aper, [s]cissors: ");
            string playerMove = Console.ReadLine();

            if (playerMove == "r" || playerMove == "rock")
            {
                playerMove = Rock;
            }
            else if (playerMove == "p" || playerMove == "paper")
            {
                playerMove = Paper;
            }else if (playerMove == "s" || playerMove == "scissors")
            {
                playerMove = Scissors;
            } else
            {
                Console.WriteLine("Invalid Input. Try again...");
                return;
            }

            Random random = new Random();
            int computerRandomNumber = random.Next(1, 4);
            string computerMove = "";

            switch(computerRandomNumber)
            {
                case 1: computerMove = Rock;
                    break;
                case 2: computerMove = Paper;
                    break;
                case 3: computerMove = Scissors;
                    break;
            }

            Console.WriteLine($"The computer chose: {computerMove}.");

            if ((playerMove == Rock && computerMove == Scissors) || (playerMove == Paper && computerMove == Rock) || (playerMove == Scissors && computerMove == Paper))
            {
                Console.WriteLine("You win.");
            } else if ((computerMove == Rock && playerMove == Scissors) || (computerMove == Paper && playerMove == Rock) || (computerMove == Scissors && playerMove == Paper))
            {
                Console.WriteLine("You lose.");
            } else if ((playerMove == Rock && computerMove == Rock) || (playerMove == Paper && computerMove == Paper) || (playerMove == Scissors && computerMove == Scissors))
            {
                Console.WriteLine("This game was a draw.");
            }

        }
    }
}