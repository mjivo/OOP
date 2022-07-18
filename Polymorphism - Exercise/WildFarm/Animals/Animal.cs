namespace WildFarm.Animals
{
    using WildFarm.Foods;
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract string Sound();
        public virtual void Eat(Food food)
        {
            throw new System.Exception($"{GetType().Name} does not eat {food.ToString()}!");
        }
    }
}
