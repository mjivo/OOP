using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double _radius;
        public Circle(double r)
        {
            this.Radius = r;
        }
        public double Radius
        {
            get { return this._radius; }
            private set { this._radius = value; }
        }
        public override double CalculatePerimeter()
        {
            return 2 * this.Radius * Math.PI;
        }
        public override double CalculateArea()
        {
            return this.Radius * this.Radius * Math.PI;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
