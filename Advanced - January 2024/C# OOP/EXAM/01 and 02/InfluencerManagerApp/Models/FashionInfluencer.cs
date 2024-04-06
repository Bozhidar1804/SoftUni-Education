using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private double factor = 0.1;
        public FashionInfluencer(string username, int followers) : base(username, followers, 4)
        {
        }

        public override int CalculateCampaignPrice()
        {
            int result = (int)Math.Floor(Followers * EngagementRate * factor);
            return result;
        }
    }
}
