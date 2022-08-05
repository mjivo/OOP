namespace ValidationAttributes
{
    using System;
    using ValidationAttributes.Models;
    public class StartUp
    {
        public static void Main()
        {
            var person = new Person
             (
                 "Pesho",
                 33
             );
            bool isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);
        }
    }
}
