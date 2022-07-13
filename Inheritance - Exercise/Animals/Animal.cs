using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string _gender = string.Empty;
        private string _name = string.Empty;
        private int _age = 0;
        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name
        {
            get => _name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(this.Name), "");
                _name = value;
            }
        }
        public string Gender
        {
            get => _gender;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(this.Name), "");
                _gender = value;
            }
        }
        public int Age
        {
            get => _age;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentNullException(nameof(this.Name), "");
                _age = value;
            }
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
               .AppendLine(GetType().Name)
               .AppendLine($"{this.Name} {this.Age} {this.Gender}")
               .AppendLine(this.ProduceSound());
            return stringBuilder.ToString().TrimEnd();

            //return $"{GetType().Name}{Environment.NewLine}" +    $"{this.Name} {this.Age} {this.Gender}{Environment.NewLine}" +  $"{this.ProduceSound()}".TrimEnd();
        }
    }
}
