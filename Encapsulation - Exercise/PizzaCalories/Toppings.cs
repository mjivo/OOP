
namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Toppings : Food
    {
        private string _type;
        public Toppings(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }
        private double Grams
        {
            get => base._grams;
            set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{this._type} weight should be in the range [1..50].");
                }
                base._grams = value;
            }
        }
        private string Type
        {
            get => this._type;
            set
            {
                string type = value;
                value = value.ToLower();
                if (value == "meat")
                {
                    base.calModifier *= 1.2;
                }
                else if (value == "veggies")
                {
                    base.calModifier *= 0.8;
                }
                else if (value == "cheese")
                {
                    base.calModifier *= 1.1;
                }
                else if (value == "sauce")
                {
                    base.calModifier *= 0.9;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {type} on top of your pizza.");
                }
                this._type = type;
            }
        }
    }
}
