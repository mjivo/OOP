using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            //base.Name = name;
            //base.Age = age;
        }

        public override int Age
        {
            get { return base.Age; }
            protected set
            {
                if (value > 15)
                {
                    //not changing for jujge
                    base.Age = value;
                }
                else
                {
                    base.Age = value;
                }
            }
        }
    }
}
