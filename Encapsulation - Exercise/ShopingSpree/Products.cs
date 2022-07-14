using System;
using System.Collections.Generic;
using System.Text;

namespace ShopingSpree
{
    public class Products : Base
    {
        private decimal _cost;
        public Products(string name, decimal cost) : base(name)
        {
            this.Cost = cost;
        }
        public decimal Cost
        {
            get => this._cost;
            set
            {
                if (base.IsValueValid(value))
                {
                    throw new Exception("Money cannot be negative");
                }
                this._cost = value;
            }
        }
        public override string ToString()
        {
            return base.Name;
        }
    }
}
