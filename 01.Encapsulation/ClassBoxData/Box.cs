using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double l, double w, double h)
        {
            this.Length = l;
            this.Width = w;
            this.Height = h;
        }
        public double Perimeter => this.Width * 2 + this.Length * 2;
        public double Length
        {
            get { return _length; }
            private set
            {
                _length = ValidateLength(value, nameof(this.Length));
            }
        }
        public double Width
        {
            get { return _width; }
            private set
            {
                _width = ValidateLength(value, nameof(this.Width));
            }
        }
        public double Height
        {
            get { return _height; }
            private set
            {
                _height = ValidateLength(value, nameof(this.Height));
            }
        }

        private double ValidateLength(double value, string prop)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{prop} cannot be zero or negative.");
            }
            return value;
        }
        public double LateralSurfaceArea()
        {
            return this.Perimeter * this.Height;
        }
        public double SurfaceArea()
        {
            return (this.Width * this.Length) * 2 + LateralSurfaceArea();
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
