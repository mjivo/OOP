namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Food
    {
        private const double _baseCalories = 2;
        public Food()
        {
        }
        protected double _grams;
        protected double calModifier = 1;
        public double CaloriesPerGram => this.Calories();
        private double Calories()
        {
            return _baseCalories * this._grams * this.calModifier;
        }
    }
}
