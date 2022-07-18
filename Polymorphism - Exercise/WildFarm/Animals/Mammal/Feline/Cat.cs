namespace WildFarm.Animals.Mammal.Feline
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Foods;

    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }
        public override string Sound() => "Meow";
        public override void Eat(Food food)
        {
            if (!(food is Meat || food is Vegetable))
            {
                base.Eat(food);
            }
            base.Weight += 0.30 * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
