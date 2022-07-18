namespace WildFarm.Foods
{
    using System;
    public abstract class Food
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; private set; }
        public override string ToString()
        {
            return $"{GetType().Name}";
        }

    }
}
