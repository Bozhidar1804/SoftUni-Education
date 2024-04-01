using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int initializingStamina = 6;
        public NaturalClimber(string name) : base(name, initializingStamina)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount * 2;
        }
    }
}
