using System;
using System.Collections.Generic;

namespace Learning05
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Build a list of shapes
            var shapes = new List<Shape>
            {
                new Square("Red", 5),
                new Rectangle("Blue", 4, 6),
                new Circle("Green", 3)
            };

            // 2. Iterate and display color & area
            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    $"Type: {shape.GetType().Name}, " +
                    $"Color: {shape.GetColor()}, " +
                    $"Area: {shape.GetArea():F2}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
