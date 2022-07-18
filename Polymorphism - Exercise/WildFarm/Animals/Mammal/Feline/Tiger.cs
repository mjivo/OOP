namespace WildFarm.Animals.Mammal.Feline
{
    using WildFarm.Foods;
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }
        public override string Sound() => "ROAR!!!";
        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                base.Eat(food);
            }
            base.Weight += 1.00 * food.Quantity;
            base.FoodEaten += food.Quantity;
        }
    }
}
