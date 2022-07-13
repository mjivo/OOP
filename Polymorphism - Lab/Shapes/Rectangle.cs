using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double _width;
        private double _height;
        public Rectangle(double height, double width)
        {
            this.Width = width;
            this.Height = height;
        }
        public double Width
        {
            get { return this._width; }
            private set { this._width = value; }
        }
        public double Height
        {
            get { return this._height; }
            private set { this._height = value; }
        }
        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }
        public override double CalculatePerimeter()
        {
            return (this.Width + this.Height) * 2;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
