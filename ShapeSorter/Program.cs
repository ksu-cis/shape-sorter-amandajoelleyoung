using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6,7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0, 4.0),
                new Circle(6.0),
                new Square(10),
            };

            foreach(IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("\n~\n");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with an area > 50");
            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("\n~\n");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine("All circles");
            foreach (Circle circle in circles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("\n~\n");

            Console.WriteLine("All circles with area > 50");
            IEnumerable<Circle> filteredCircles = shapes.OfType<Circle>().Where(circ => circ.Area < 50);

            foreach (Circle circle in filteredCircles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("\n~\n");

            Console.WriteLine("Grouping by Area");
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach (var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Evens" : "Odds");
                foreach (var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("\n~\n");


            Console.WriteLine("Group by Type");
            var groupByType = shapes.GroupBy(shape => shape.GetType());
            foreach (var group in groupByType)
            {
                foreach (var shape in group)
                {
                    Console.WriteLine($"{group.Key.Name} with area {shape.Area}");
                }
            }
            Console.WriteLine("\n~\n");



            Console.ReadKey();
        }
    }
}
