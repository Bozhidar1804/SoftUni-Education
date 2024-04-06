using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private List<ICampaign> campaigns = new List<ICampaign>();
        public IReadOnlyCollection<ICampaign> Models
        {
            get { return campaigns.AsReadOnly(); }
        }
        public void AddModel(ICampaign model)
        {
            campaigns.Add(model);
        }

        public bool RemoveModel(ICampaign model)
        {
            foreach (ICampaign campaign in campaigns)
            {
                if (model == campaign)
                {
                    campaigns.Remove(model);
                    return true;
                }
            }

            return false;
        }

        public ICampaign FindByName(string name)
        {
            return campaigns.FirstOrDefault(c => c.Brand == name);
        }
    }
}
