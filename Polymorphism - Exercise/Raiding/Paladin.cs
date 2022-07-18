using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : this(name, 100)
        {

        }
        public Paladin(string name, int power)
            : base(name, power)
        {
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} healed for {base.Power}";
        }
    }
}
