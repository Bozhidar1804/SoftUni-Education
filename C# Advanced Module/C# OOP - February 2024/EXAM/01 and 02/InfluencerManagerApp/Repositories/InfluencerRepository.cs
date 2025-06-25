using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private List<IInfluencer> influencers = new List<IInfluencer>();
        public IReadOnlyCollection<IInfluencer> Models
        {
            get { return influencers.AsReadOnly(); }
        }
        public void AddModel(IInfluencer model)
        {
            influencers.Add(model);
        }

        public bool RemoveModel(IInfluencer model)
        {
            foreach (IInfluencer influencer in influencers)
            {
                if (model == influencer)
                {
                    influencers.Remove(model);
                    return true;
                }
            }

            return false;
        }

        public IInfluencer FindByName(string name)
        {
            return influencers.FirstOrDefault(i => i.Username == name);
        }
    }
}
