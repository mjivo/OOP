using System;
using System.Collections.Generic;
using System.Text;

namespace ShopingSpree
{
    public class Base
    {
        private string _name;
        public Base(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this._name = value;
            }
        }

        protected bool IsValueValid(decimal value)
        {
            return value < 0;
        }
    }
}
