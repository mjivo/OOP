using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }
        public string Breed { get; private set; }
        public override string ToString()
        {
            return $"{GetType().Name} [{base.Name}, {this.Breed}, {this.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
