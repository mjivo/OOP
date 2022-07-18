using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : this(name, 80)
        {
        }
        public Rogue(string name, int power)
            : base(name, power)
        {
        }
        public override string CastAbility()
        {
           return $"{GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
