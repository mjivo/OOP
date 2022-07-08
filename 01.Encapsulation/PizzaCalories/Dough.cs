namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Dough : Food
    {
        private string _flourType;
        private string _bakingTechnique;
        private const string ExceptionMsg = "Invalid type of dough.";
        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }
        private double Grams
        {
            get => base._grams;
            set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                base._grams = value;
            }
        }
        private string BakingTechnique
        {
            get => this._bakingTechnique;
            set
            {
                string type = value;
                value = value.ToLower();
                if (value == "crispy")
                {
                    base.calModifier *= 0.9;
                }
                else if (value == "chewy")
                {
                    base.calModifier *= 1.1;
                }
                else if (value == "homemade")
                {
                    base.calModifier *= 1.0;
                }
                else
                {
                    throw new ArgumentException(ExceptionMsg);
                }
                this._bakingTechnique = type;
            }
        }
        private string FlourType
        {
            get => this._flourType;
            set
            {
                string type = value;
                value = value.ToLower();
                if (value == "white")
                {
                    base.calModifier *= 1.5;
                }
                else if (value == "wholegrain")
                {
                    base.calModifier *= 1.0;
                }
                else
                {
                    throw new ArgumentException(ExceptionMsg);
                }
                this._flourType = type;
            }
        }

    }
}
