using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race_second_try_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> validParticipants = Console.ReadLine().Split(", ").ToList();
            List<Participant> participants = new List<Participant>();

            foreach (string name in validParticipants)
            {
                Participant participant = new Participant(name);
                participants.Add(participant);
            }

            string lettersPattern = @"[A-Za-z]";
            string digitsPattern = @"\d";
            string command = "";

            while ((command = Console.ReadLine()) != "end of race")
            {
                StringBuilder currentName = new StringBuilder();
                MatchCollection lettersMatches = Regex.Matches(command, lettersPattern);
                foreach (Match match in lettersMatches)
                {
                    currentName.Append(match.Value);
                }


                uint currentDistance = 0;
                MatchCollection digitsMatches = Regex.Matches(command, digitsPattern);
                foreach (Match match in digitsMatches)
                {
                    currentDistance += uint.Parse(match.Value);
                }

                Participant foundParticipant = participants.FirstOrDefault(p => p.Name == currentName.ToString());
                if (foundParticipant != null)
                {
                    foundParticipant.Distance += currentDistance;
                }

            }

            List<Participant> firstThreeParticipants = participants.OrderByDescending(p => p.Distance).Take(3).ToList();
            Console.WriteLine($"1st place: {firstThreeParticipants[0].Name}");
            Console.WriteLine($"2nd place: {firstThreeParticipants[1].Name}");
            Console.WriteLine($"3rd place: {firstThreeParticipants[2].Name}");

        }
    }

    class Participant
    {
        public Participant (string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public uint Distance { get; set; }
    }
}