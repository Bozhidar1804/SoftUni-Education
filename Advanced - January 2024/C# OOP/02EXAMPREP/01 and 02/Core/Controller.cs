using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> _peaks;
        private IRepository<IClimber> _climbers;
        private IBaseCamp _baseCamp;

        public Controller()
        {
            _peaks = new PeakRepository();
            _climbers = new ClimberRepository();
            _baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (_peaks.Get(name) != null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel is not ("Extreme" or "Hard" or "Moderate"))
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            IPeak currentPeak = new Peak(name, elevation, difficultyLevel);
            _peaks.Add(currentPeak);
            return string.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository));
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (_climbers.Get(name) != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));
            }

            IClimber climber = null;
            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }
            _climbers.Add(climber);
            _baseCamp.ArriveAtCamp(climber.Name);
            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (_climbers.Get(climberName) == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (_peaks.Get(peakName) == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!_baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            IPeak peak = _peaks.Get(peakName);
            IClimber climber = _climbers.Get(climberName);
            if (peak.DifficultyLevel == "Extreme" && climber is NaturalClimber)
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            _baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);
            if (climber.Stamina <= 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            else
            {
                _baseCamp.ArriveAtCamp(climberName);
                return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
            }
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!_baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = _climbers.Get(climberName);
            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            climber.Rest(daysToRecover);
            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");
            foreach (string climberName in _baseCamp.Residents)
            {
                IClimber climber = _climbers.Get(climberName);
                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }
            return sb.ToString().Trim();

        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            List<IClimber> climbersOrdered = _climbers.All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name)
                .ToList();
            foreach (IClimber climber in climbersOrdered)
            {
                sb.AppendLine(climber.ToString());
                List<IPeak> currentClimberPeaks = new List<IPeak>();
                foreach (string peakName in climber.ConqueredPeaks)
                {
                    currentClimberPeaks.Add(_peaks.Get(peakName));
                }

                foreach (IPeak peak in currentClimberPeaks.OrderByDescending(p => p.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
