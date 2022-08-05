namespace ValidationAttributes.Utilities
{
    using System;
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class MyValidationAttribute : Attribute
    {
        public MyValidationAttribute()
        {
        }
        public abstract bool IsValid(object obj);
    }
}
