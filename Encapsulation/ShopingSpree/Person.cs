using System;
using System.Collections.Generic;
using System.Text;

namespace ShopingSpree
{
    public class Person : Base
    {
        private decimal _money;
        private readonly List<Products> _bag;
        public Person(string name, decimal money) : base(name)
        {
            this.Money = money;
            this._bag = new List<Products>();
        }
        public IReadOnlyList<Products> Bag
        {
            get => _bag;
        }
        public decimal Money
        {
            get => this._money;
            set
            {
                if (base.IsValueValid(value))
                {
                    throw new Exception("Money cannot be negative");
                }
                this._money = value;
            }
        }
        public void AddProductToTheBag(Products product)
        {
            //base.Money -= product.Cost;
            _bag.Add(product);
        }

    }
}
