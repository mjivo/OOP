namespace WildFarm.Animals.Birds
{
    using WildFarm.Foods;
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }
        public override string Sound() => "Cluck";
        public override void Eat(Food food)
        {
            base.Weight += 0.35 * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
