using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> caughtFish;
        private double competitionPoints;
        private bool hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            caughtFish = new List<string>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                this.name = value;
            }
        }

        public int OxygenLevel
        {
            get { return this.oxygenLevel; }
            protected set
            {
                if (value <= 0)
                {
                    HasHealthIssues = true;
                    oxygenLevel = 0;
                }
                else
                {
                    oxygenLevel = value;
                }
            }
        }
        public IReadOnlyCollection<string> Catch
        {
            get { return this.caughtFish.AsReadOnly(); }
        }

        public double CompetitionPoints
        {
            get { return this.competitionPoints; }
            private set
            {
                this.competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get { return this.hasHealthIssues; }
            private set { this.hasHealthIssues = value; }
        }


        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            caughtFish.Add(fish.Name);
            CompetitionPoints = Math.Round(competitionPoints + fish.Points, 1);
        }

        public abstract void Miss(int TimeToCatch);

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public abstract void RenewOxy();

        public override string ToString()
        {
            return
                $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
