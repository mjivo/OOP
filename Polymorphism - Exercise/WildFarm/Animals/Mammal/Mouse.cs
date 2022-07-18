namespace WildFarm.Animals.Mammal
{
    using WildFarm.Foods;
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }
        public override string Sound() => "Squeak";
        public override void Eat(Food food)
        {
            if (!(food is Vegetable || food is Fruit))
            {
                base.Eat(food);
            }
            base.Weight += 0.1 * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
