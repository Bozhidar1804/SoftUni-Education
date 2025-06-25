using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        private double budget;
        private List<string> contributors;

        public Campaign(string brand, double budget)
        {
            Brand = brand;
            Budget = budget;
            contributors = new List<string>();
        }

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }
                brand = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set { budget = value; }
        }

        public IReadOnlyCollection<string> Contributors
        {
            get { return contributors.AsReadOnly(); }
        }
        public void Gain(double amount)
        {
            Budget += amount;
        }

        public void Engage(IInfluencer influencer)
        {
            string influencerType = influencer.GetType().Name;
            if (influencerType == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(influencer.Username, influencer.Followers);
            } else if (influencerType == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(influencer.Username, influencer.Followers);
            } else if (influencerType == nameof(BloggerInfluencer))
            {
                influencer = new BloggerInfluencer(influencer.Username, influencer.Followers);
            }

            contributors.Add(influencer.Username);
            Budget -= influencer.CalculateCampaignPrice();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
        }
    }
}
