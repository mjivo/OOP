using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : this(name, 100)
        {
        }
        public Warrior(string name, int power)
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
