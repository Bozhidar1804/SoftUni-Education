using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fish;
        private string[] validDivers = new string[] { nameof(ScubaDiver), nameof(FreeDiver)};
        private string[] validFish = new string[] { nameof(ReefFish), nameof(DeepSeaFish), nameof(PredatoryFish) };

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!validDivers.Contains(diverType))
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return String.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
            }

            IDiver diver = null;
            if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
            } else if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            divers.AddModel(diver);
            return String.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!validFish.Contains(fishType))
            {
                return String.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fish.GetModel(fishName) != null)
            {
                return String.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }

            IFish currentFish = null;
            if (fishType == nameof(ReefFish))
            {
                currentFish = new ReefFish(fishName, points);
            } else if (fishType == nameof(DeepSeaFish))
            {
                currentFish = new DeepSeaFish(fishName, points);
            } else if (fishType == nameof(PredatoryFish))
            {
                currentFish = new PredatoryFish(fishName, points);
            }
            fish.AddModel(currentFish);
            return String.Format(OutputMessages.FishCreated, fishName);
        }

        public string HealthRecovery()
        {
            List<IDiver> issuedDivers = divers.Models.Where(d => d.HasHealthIssues).ToList();
            foreach (var diver in issuedDivers)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return String.Format(OutputMessages.DiversRecovered, issuedDivers.Count);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(diver.ToString());

            sb.AppendLine("Catch Report:");

            foreach (var caughtFish in diver.Catch)
            {
                sb.AppendLine(fish.GetModel(caughtFish).ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            List<IDiver> checkedDivers = divers.Models.Where(d => !d.HasHealthIssues)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in checkedDivers)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }
        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return String.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }

            if (fish.GetModel(fishName) == null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);
            if (diver.HasHealthIssues)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            IFish currentFish = fish.GetModel(fishName);
            if (diver.OxygenLevel < currentFish.TimeToCatch)
            {
                diver.Miss(currentFish.TimeToCatch);
                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            } else if (diver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(currentFish);
                    return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
                } else
                {
                    diver.Miss(currentFish.TimeToCatch);
                    return String.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            } else
            {
                diver.Hit(currentFish);
                return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }
        }
    }
}
