using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;
        private string[] validInfluencerTypes = new string[] { nameof(FashionInfluencer), nameof(BusinessInfluencer), nameof(BloggerInfluencer)};
        private string[] validCampaignTypes = new string[] { nameof(ProductCampaign), nameof(ServiceCampaign) };

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }
        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (!validInfluencerTypes.Contains(typeName))
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            IInfluencer influencer = null;
            if (typeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else if (typeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == nameof(BloggerInfluencer))
            {
                influencer = new BloggerInfluencer(username, followers);
            }
            influencers.AddModel(influencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (!validCampaignTypes.Contains(typeName))
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign campaign = null;
            if (typeName == nameof(ProductCampaign))
            {
                campaign = new ProductCampaign(brand);
            } else if (typeName == nameof(ServiceCampaign))
            {
                campaign = new ServiceCampaign(brand);
            }
            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            if (influencers.FindByName(username) == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            }

            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            IInfluencer currentInfluencer = influencers.FindByName(username);
            ICampaign currentCampaign = campaigns.FindByName(brand);
            if (currentCampaign.Contributors.Contains(currentInfluencer.Username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            bool isEligible = false;
            if (currentCampaign.GetType().Name == nameof(ProductCampaign))
            {
                if (currentInfluencer.GetType().Name == nameof(BusinessInfluencer) ||
                    currentInfluencer.GetType().Name == nameof(FashionInfluencer))
                {
                    isEligible = true;
                }
            } else if (currentCampaign.GetType().Name == nameof(ServiceCampaign))
            {
                if (currentInfluencer.GetType().Name == nameof(BusinessInfluencer) ||
                    currentInfluencer.GetType().Name == nameof(BloggerInfluencer))
                {
                    isEligible = true;
                }
            }

            if (!isEligible)
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (currentCampaign.Budget < currentInfluencer.CalculateCampaignPrice()) // !!! possible mistake
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            currentInfluencer.EarnFee(currentInfluencer.CalculateCampaignPrice());
            currentInfluencer.EnrollCampaign(brand);
            currentCampaign.Engage(currentInfluencer); // engage method updates budget too
            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            ICampaign currentCampaign = campaigns.FindByName(brand);
            currentCampaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }

            ICampaign currentCampaign = campaigns.FindByName(brand);

            bool campaignMeetsCriteria = false;
            if (currentCampaign.Budget > 10000)
            {
                campaignMeetsCriteria = true;
            }

            if (!campaignMeetsCriteria)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            if (campaignMeetsCriteria)
            {
                List<IInfluencer> currentInfluencers = new List<IInfluencer>();
                foreach (string influencerName in currentCampaign.Contributors)
                {
                    currentInfluencers.Add(influencers.FindByName(influencerName));
                }

                foreach (IInfluencer influencer in currentInfluencers)
                {
                    influencer.EarnFee(2000);
                    foreach (string campaignName in influencer.Participations)
                    {
                        if (currentCampaign.Brand == campaignName)
                        {
                            influencer.EndParticipation(campaignName);
                            break;
                        }
                    }
                }
            }

            campaigns.RemoveModel(currentCampaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            if (influencers.FindByName(username) == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            IInfluencer currentInfluencer = influencers.FindByName(username);
            if (currentInfluencer.Participations.Count >= 1)
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(currentInfluencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IInfluencer> influencersOrdered = influencers.Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers)
                .ToList();
            foreach (IInfluencer influencer in influencersOrdered)
            {
                sb.AppendLine($"{influencer.ToString()}");
                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (string campaignName in influencer.Participations)
                    {
                        ICampaign currentCampaign = campaigns.FindByName(campaignName);
                        sb.AppendLine($"--{currentCampaign.ToString()}");
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}
