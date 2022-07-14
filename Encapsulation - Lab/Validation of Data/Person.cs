using System;
using System.Collections.Generic;
using System.Text;
namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        private const string ArgExcMsgForInvalidName = "{0} name cannot contain fewer than 3 symbols!";
        public Person(string firstname, string lastName, int age, decimal salary)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (IsNameValid(value))
                {
                    throw new ArgumentException(string.Format(ArgExcMsgForInvalidName, "First"));
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (IsNameValid(value))
                {
                    throw new ArgumentException(string.Format(ArgExcMsgForInvalidName, "Last"));
                }
                this.lastName = value;
            }
        }
        public int Age
        {
            get => this.age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }
        public decimal Salary
        {
            get => this.salary;
            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                this.salary = value;
            }
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage = percentage / 2;
            }

            this.Salary += this.Salary * percentage / 100;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
        private bool IsNameValid(string value) => value.Length < 3;
    }
}
