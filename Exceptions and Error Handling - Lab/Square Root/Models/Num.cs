namespace Square_Root
{
    using System;
    public class Num
    {
        private int _value;
        public Num(int value)
        {
            this.Value = value;
        }
        public int Value
        {
            get => this._value;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidCastException("Invalid number.");
                }
                this._value = value;
            }
        }
        public double SquareRoot => Math.Round(Math.Sqrt(this.Value), 2);
    }
}
