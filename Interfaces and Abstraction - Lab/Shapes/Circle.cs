using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private const string EceptiomMsg = "{0} cannot be negative";

        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int Radius
        {
            get => this.radius;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(EceptiomMsg, nameof(this.Radius)));
                }
                this.radius = value;
            }
        }
        public void Draw()
        {
            double @in = this.Radius - 0.4;
            double @out = this.Radius + 0.4;
            for (double i = this.Radius; i >= -this.Radius; --i)
            {
                for (double j = -this.Radius; j < @out; j += 0.5)
                {
                    double value = j * j + i * i;
                    if (value >= @in * @in && value <= @out * @out)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
