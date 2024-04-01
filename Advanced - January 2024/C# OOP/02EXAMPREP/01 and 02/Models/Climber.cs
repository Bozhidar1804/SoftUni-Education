using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        public Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Stamina
        {
            get { return stamina; }
            protected set
            {
                if (value < 0)
                {
                    stamina = 0;
                } else if (value > 10)
                {
                    stamina = 10;
                }
                else
                {
                    stamina = value;
                }
            }
        }
        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();
        public void Climb(IPeak peak)
        {
            if (!ConqueredPeaks.Contains(peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                Stamina -= 4;
            } else if (peak.DifficultyLevel == "Moderate")
            {
                Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.Append("Peaks conquered: ");

            if (ConqueredPeaks.Count > 0)
            {
                sb.AppendLine($"{conqueredPeaks.Count}");
            }
            else
            {
                sb.Append("no peaks conquered");
            }
            return sb.ToString().Trim();
        }
    }
}
