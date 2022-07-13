namespace Food
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Rebel : INamable, IAgeable, IBuyable
    {
        private int _food = 0;
        public Rebel(string name, int age, string group)
        {
            this.Age = age;
            this.Name = name;
        }

        public int Food
        {
            get
            {
                return _food;
            }
            set
            {
                _food = value;
            }
        }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int BuyFood()
        {
            this.Food += 5;
            return 5;
        }
    }
}
