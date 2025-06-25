using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private List<string> residents;

        public BaseCamp()
        {
            residents = new List<string>();
        }

        public IReadOnlyCollection<string> Residents => residents.AsReadOnly();
        public void ArriveAtCamp(string climberName)
        {
            residents.Add(climberName);
            residents = residents.OrderBy(r => r).ToList();
        }

        public void LeaveCamp(string climberName)
        {
            if (residents.Contains(climberName))
            {
                residents.Remove(climberName);
            }
        }
    }
}
