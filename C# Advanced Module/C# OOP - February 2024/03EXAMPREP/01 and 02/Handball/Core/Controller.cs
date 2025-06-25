using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;
        private string[] validPlayers = new string[] { nameof(Goalkeeper), nameof(CenterBack), nameof(ForwardWing) };

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            ITeam team;
            if (teams.GetModel(name) != null)
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            team = new Team(name);
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));
        }

        public string NewPlayer(string typeName, string name)
        {
            if (!validPlayers.Contains(typeName))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (players.GetModel(name) != null)
            {
                IPlayer existingPlayer = players.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository),
                    existingPlayer.GetType().Name);
            }

            IPlayer player = null;
            if (typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            } else if (typeName == "ForwardWing")
            {
                player = new ForwardWing(name);
            } else if (typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (players.GetModel(playerName) == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            if (teams.GetModel(teamName) == null)
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer player = players.GetModel(playerName);
            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            ITeam team = teams.GetModel(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            ITeam winningTeam = null;
            ITeam losingTeam = null;
            bool isDraw = false;
            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                winningTeam = firstTeam;
                losingTeam = secondTeam;
            } else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                winningTeam = secondTeam;
                losingTeam = firstTeam;
            }
            else
            {
                isDraw = true;
            }

            if (!isDraw)
            {
                winningTeam.Win();
                losingTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, winningTeam.Name, losingTeam.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = teams.GetModel(teamName);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            List<IPlayer> playersOfTheTeam = new List<IPlayer>();
            foreach (IPlayer player in team.Players)
            {
                playersOfTheTeam.Add(player);
            }

            playersOfTheTeam = playersOfTheTeam.OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name)
                .ToList();

            foreach (IPlayer player in playersOfTheTeam)
            {
                sb.AppendLine($"{player.ToString()}");
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***League Standings***");

            List<ITeam> teamsList = teams.Models.OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name)
                .ToList();

            foreach (ITeam team in teamsList)
            {
                sb.AppendLine($"{team.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
