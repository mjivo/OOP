using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            IDrawable circle = new Circle(int.Parse(Console.ReadLine()));
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);
            circle.Draw();
            rect.Draw();
        }
    }
}
