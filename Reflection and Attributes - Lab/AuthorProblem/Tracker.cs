namespace AuthorProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type startUpType = typeof(StartUp);
            MethodInfo[] methods = startUpType.GetMethods
                (
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance
                ).Where(m => m.GetCustomAttributes().Any(a => a.TypeId == typeof(AuthorAttribute))).ToArray();

            foreach (MethodInfo method in methods)
            {
                AuthorAttribute attribute = method.GetCustomAttribute(typeof(AuthorAttribute)) as AuthorAttribute;

                Console.WriteLine($"{method.Name/*FullName*/} is written by {attribute.Name}");
            }
        }
    }
}
