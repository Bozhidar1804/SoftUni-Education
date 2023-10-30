using System.Net.NetworkInformation;

namespace _05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] createTeam = Console.ReadLine().Split("-");
                string user = createTeam[0];
                string teamName = createTeam[1];

                if (hasUserAlreadyCreated(user, teams))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                } else if (isTeamAlreadyCreated(teamName, teams)) {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                } else
                {
                    Team team = new Team(user, teamName);
                    teams.Add(team);
                    Console.WriteLine($"Team {team.TeamName} has been created by {user}!");
                }
            }

            string command = "";
            while (command != "end of assignment")
            {
                command = Console.ReadLine();
                if (command == "end of assignment") break;

                string[] commandArr = command.Split("->");
                string userJoining = commandArr[0];
                string teamName = commandArr[1];

                if (!teamExists(teamName, teams))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                } else if (userIsAlreadyInTeam(userJoining, teams))
                {
                    Console.WriteLine($"Member {userJoining} cannot join team {teamName}!");
                    continue;
                } else
                {
                    foreach (Team team in teams)
                    {
                        if (teamName == team.TeamName)
                        {
                            team.Users.Add(userJoining);
                        }
                    }
                }
            }
            List<Team> leftTeams = teams.Where(t =>t.Users.Count > 0).ToList();
            List<Team> orderedValidTeams = leftTeams
                .OrderByDescending(x => x.Users.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            foreach (Team team in orderedValidTeams)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                List<string> sortedUsers = team.Users.ToList();
                sortedUsers.Sort();
                for (int i = 0; i < sortedUsers.Count; i++)
                {
                    Console.WriteLine($"-- {sortedUsers[i]}");
                }
            }

            Console.WriteLine("Teams to disband:");
            List<Team> teamsDisband = new List<Team>();
            foreach(Team team in teams)
            {
                if (team.Users.Count == 0)
                {
                    teamsDisband.Add(team);
                }
            }
            List<Team> disbandedByAscending = teamsDisband.OrderBy(x => x.TeamName).ToList();
            foreach(Team team in teamsDisband)
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }


        public static bool userIsAlreadyInTeam(string userJoining, List<Team> teams)
        {
            bool result = false;

            foreach (Team team in teams)
            {
                if (userJoining == team.Creator)
                {
                    result = true;
                }

                for (int i = 0; i < team.Users.Count; i++)
                {
                    if (userJoining == team.Users[i])
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
        
        public static bool teamExists(string teamName, List<Team> teams)
        {
            bool result = false;

            foreach (Team team in teams)
            {
                if (teamName == team.TeamName)
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool hasUserAlreadyCreated(string user, List<Team> teams)
        {
            bool result = false;

            foreach (Team team in teams)
            {
                if (user == team.Creator)
                {
                    result = true;
                }

                for (int i = 0; i < team.Users.Count; i++)
                {
                    if (user == team.Users[i])
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public static bool isTeamAlreadyCreated(string teamName, List<Team> teams)
        {
            bool result = false;

            foreach (Team team in teams)
            {
                if (teamName == team.TeamName)
                {
                    result = true;
                }
            }

            return result;
        }
    }

    class Team
    {
        public Team(string creator, string teamName)
        {
            Creator = creator;
            Users = new List<string>();
            TeamName = teamName;
        }
        public string Creator { get; set; }
        public List<string> Users { get; set; }

        public string TeamName { get; set; }
    }
}