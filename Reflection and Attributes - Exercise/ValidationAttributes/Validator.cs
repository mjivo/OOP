namespace ValidationAttributes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Utilities;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType
                .GetProperties(BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Static
                | BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes().Any(att => att.GetType().BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            object result = false;
            foreach (PropertyInfo property in properties)
            {
                object propertyValue = property.GetValue(obj);
                foreach (Attribute attribute in property.GetCustomAttributes()
                    .Where(att => att.GetType().BaseType == typeof(MyValidationAttribute)))
                {
                    Type attributeType = attribute.GetType();
                    object attributeInstance = property.GetCustomAttribute(attributeType);
                    MethodInfo attributeMethd = attributeType.GetMethod(nameof(IsValid));
                    result = attributeMethd.Invoke(attributeInstance, new object[] { propertyValue });
                    if (result is bool res && res == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
