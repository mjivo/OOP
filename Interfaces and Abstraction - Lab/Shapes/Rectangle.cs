using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private const string EceptiomMsg = "{0} cannot be negative";

        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width
        {
            get => this.width;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(EceptiomMsg, nameof(this.Width)));
                }
                this.width = value;
            }
        }
        public int Height
        {
            get => this.height;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(EceptiomMsg, nameof(this.Height)));
                }
                this.height = value;
            }
        }
        public void Draw()
        {
            DrawLine('*', '*');
            for (int i = 0; i < this.Height - 2; i++)
            {
                DrawLine('*', ' ');
            }
            DrawLine('*', '*');
        }

        private void DrawLine(char outer, char inner)
        {
            Console.Write(outer);
            for (int i = 0; i < this.Width - 2; i++)
            {
                Console.Write(inner);
            }

            Console.Write(outer);
            Console.WriteLine();
        }
    }
}
