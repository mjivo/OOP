namespace Food
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    public class Pet : INamable, IBirthdateable
    {
        private string _birthdate;
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;

        }
        public string Name { get; private set; }
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
