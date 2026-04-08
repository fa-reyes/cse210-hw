using System;

class Program
{
    static void Main(string[] args)
    {
        Square s1 = new Square();
        s1.SetColor("red");
        s1.SetSide(5);

        Rectangle r1 = new Rectangle();
        r1.SetColor("yellow");
        r1.SetLength(8);
        r1.SetWidth(4);

        Circle c1 = new Circle();
        c1.SetColor("orange");
        c1.SetRadius(3);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(s1);
        shapes.Add(r1);
        shapes.Add(c1);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}");
        }
    }
}