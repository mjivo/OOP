using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int _age;
        public Person() : this("No name", 0)
        {
            this.Name = "No name";
            this.Age = 0;
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public virtual int Age
        {
            get { return this._age; }
            protected set
            {
                if (value < 0)//invalid age
                {
                    this._age = 0;
                }
                else
                {
                    this._age = value;
                }
            }
        }
        public string Name { get; protected set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");
            return stringBuilder.ToString();
        }

    }
}
