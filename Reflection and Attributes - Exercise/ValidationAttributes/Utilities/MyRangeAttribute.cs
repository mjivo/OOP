namespace ValidationAttributes.Utilities
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _minValue;
        private int _maxValue;
        public MyRangeAttribute()
        {
        }
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is int value)
                return value >= this._minValue && value <= this._maxValue;
            return false;
        }
    }
}
