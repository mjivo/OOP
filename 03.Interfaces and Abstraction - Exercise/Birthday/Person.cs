namespace Birthday
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    public class Person : INamable, IAgeable, IIdentifilable, IBirthdateable
    {
        private string _birthdate;
        public Person(string name, int age, string id, string bithdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = bithdate;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string Birthdate
        {
            get => _birthdate;
            private set
            {
                if (!ValidateDate(value))
                {
                    //error
                }
                _birthdate = value;
            }
        }

        public bool ValidateDate(string date)
        {
            return Regex.Match(date, @"[0-9]{2}\/[0-9]{2}\/[0-9]{4}").Success;
        }
    }
}
