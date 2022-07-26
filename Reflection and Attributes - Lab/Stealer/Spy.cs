namespace Stealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.Instance);
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Class under investigation: {className}");// classType.Name

            Object instace = Activator.CreateInstance(classType);
            foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
            {
                output.AppendLine($"{field.Name} = {field.GetValue(instace)}");
            }
            return output.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields
                (
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance
                );
            MethodInfo[] nonPublicMethods = classType.GetMethods
                (
                BindingFlags.NonPublic |
                BindingFlags.Instance
                );
            MethodInfo[] publicMethods = classType.GetMethods
                (
                BindingFlags.Public |
                BindingFlags.Instance
                );

            StringBuilder output = new StringBuilder();
            foreach (FieldInfo field in fields)
            {
                output.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                output.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                output.AppendLine($"{method.Name} have to be private!");
            }
            return output.ToString().Trim();
        }
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methods = classType.GetMethods
                (
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance
                );

            StringBuilder output = new StringBuilder();
            output.AppendLine($"All Private Methods of Class: {classType.Name}");
            Type baseClassType = classType.BaseType;
            output.AppendLine($"Base Class: {baseClassType.Name}");

            foreach (MethodInfo method in methods)
            {
                output.AppendLine($"{method.Name}");
            }

            return output.ToString().Trim();
        }

        
        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods
               (
               BindingFlags.NonPublic |
               BindingFlags.Static |
               BindingFlags.Public |
               BindingFlags.Instance
               );
            StringBuilder output = new StringBuilder();

            StringBuilder setters = new StringBuilder();
            foreach (MethodInfo method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    output.AppendLine($"{method.Name} will return {method.ReturnType.FullName}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    setters.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType.FullName}");
                }
            }
            output.AppendLine(setters.ToString());
            return output.ToString().Trim();
        }
    }
}
