using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Raiding
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80;
        public Druid(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
