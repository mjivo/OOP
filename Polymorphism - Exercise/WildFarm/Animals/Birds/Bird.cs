namespace WildFarm.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{base.Name}, {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
        }
    }
}
