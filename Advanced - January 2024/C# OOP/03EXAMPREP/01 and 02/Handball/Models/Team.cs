using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private double overallRating;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            pointsEarned = 0;
            players = new List<IPlayer>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get { return pointsEarned; }
        }

        public double OverallRating => this.Players.Count == 0 ? 0 : Math.Round(this.players.Average(p => p.Rating), 2);
        public IReadOnlyCollection<IPlayer> Players
        {
            get { return players.AsReadOnly(); }
        }
        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            pointsEarned += 3;
            foreach (IPlayer player in Players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (IPlayer player in Players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            pointsEarned += 1;
            this.Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {Math.Round(OverallRating, 1)}");

            List<string> playerNames = new List<string>();
            foreach (IPlayer player in Players)
            {
                playerNames.Add(player.Name);
            }

            if (playerNames.Count > 0)
            {
                sb.AppendLine($"--Players: {string.Join(", ", playerNames)}");
            }
            else
            {
                sb.AppendLine($"--Players: none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
