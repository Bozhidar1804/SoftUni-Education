using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private double factor = 0.2;
        public BloggerInfluencer(string username, int followers) : base(username, followers, 2)
        {
        }

        public override int CalculateCampaignPrice()
        {
            int result = (int)Math.Floor(Followers * EngagementRate * factor);
            return result;
        }
    }
}
