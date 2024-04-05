using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;

        public TeamRepository()
        {
            teams = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models
        {
            get { return teams.AsReadOnly(); }
        }
        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool RemoveModel(string name) => this.teams.Remove(this.teams.FirstOrDefault(t => t.Name == name));

        public bool ExistsModel(string name) => this.teams.Any(t => t.Name == name);

        public ITeam GetModel(string name) => this.teams.FirstOrDefault(t => t.Name == name);
    }
}
