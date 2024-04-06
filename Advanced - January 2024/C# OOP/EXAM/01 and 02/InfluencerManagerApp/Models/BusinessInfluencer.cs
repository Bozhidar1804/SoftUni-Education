using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private double factor = 0.15;
        public BusinessInfluencer(string username, int followers) : base(username, followers, 3)
        {
        }

        public override int CalculateCampaignPrice()
        {
            int result = (int)Math.Floor(Followers * EngagementRate * factor);
            return result;
        }
    }
}
