namespace WildFarm.Animals.Mammal
{
    using WildFarm.Foods;
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }
        public override string Sound() => "Woof!";
        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                base.Eat(food);
            }
            base.Weight += 0.40 * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
