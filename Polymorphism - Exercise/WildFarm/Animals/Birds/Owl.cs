namespace WildFarm.Animals.Birds
{
    using WildFarm.Foods;
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }
        public override string Sound() => "Hoot Hoot";
        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                base.Eat(food);
            }
            base.Weight += 0.25 * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
