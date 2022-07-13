using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string _Gender = "Male";
        public Tomcat(string name, int age) : base(name, age, _Gender)
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
