using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> fish;

        public FishRepository()
        {
            fish = new List<IFish>();
        }
        public IReadOnlyCollection<IFish> Models
        {
            get { return this.fish.AsReadOnly(); }
        }
        public void AddModel(IFish model)
        {
            fish.Add(model);
        }

        public IFish GetModel(string name)
        {
            return fish.FirstOrDefault(f => f.Name == name);
        }
    }
}
