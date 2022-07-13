using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            milliliters = this.Milliliters;
        }
        public double Milliliters { get; set; }
    }
}
