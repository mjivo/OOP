using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : this(name, 80)
        {
        }
        public Druid(string name, int power)
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} healed for {base.Power}";
        }
    }
}
