using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {

        private string _name;
        private string favouriteFood;
        public Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favoriteFood;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                this._name = value;
            }
        }
        public string FavoriteFood
        {
            get => this.favouriteFood;
            private set
            {
                this.favouriteFood = value;
            }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is Whiskas {this.FavoriteFood}{Environment.NewLine}";

        }

    }
}
