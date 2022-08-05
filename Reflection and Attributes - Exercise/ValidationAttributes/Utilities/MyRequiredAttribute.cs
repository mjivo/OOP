namespace ValidationAttributes.Utilities
{
    using System;
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public MyRequiredAttribute()
        {
        }
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
                return !string.IsNullOrEmpty(str);
            }
            return obj != null;
        }
    }
}
