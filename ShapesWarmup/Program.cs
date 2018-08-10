using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWarmup
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(3, 4);
            Console.WriteLine(rectangle.ToString());
            Square square = new Square(5, "Orange");
            Console.WriteLine(square.ToString());
            Triangle triangle = new Triangle(7, 4, 5, "Blue");
            Console.WriteLine(triangle.ToString());
            Console.Read();
        }
    }

    public abstract class Shape
    {
        protected Shape(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract double CalculateArea();


    }

    public class Rectangle : Shape
    {
        public int Length;
        public int Width;

        public Rectangle(int length, int width) : base("Rectangle")
        {
            Length = length;
            Width = width;
        }

        protected Rectangle(int length, int width, string name) : base(name)
        {
            Length = length;
            Width = width;
        }

        public override double CalculateArea()
        {
            return Length * Width;
        }

        public override string ToString()
        {
            return $"This {Name} has area {CalculateArea():N}";
        }
    }

    public interface IColor
    {
        string GetColor();
    }

    public class Square : Rectangle, IColor
    {
        public string Color;

        public Square(int sideLength, string color) : base(sideLength, sideLength, "Square")
        {
            Color = color;
        }

        public string GetColor()
        {
            return Color;
        }

        public override string ToString()
        {
            return $"{base.ToString()} and is the color {Color}";
        }
    }

    public class Triangle : Shape, IColor
    {
        int Side1Length, Side2Length, Side3Length;
        string Color;

        public Triangle(int side1Length, int side2Length, int side3Length, string color) : base("Triangle")
        {
            Side1Length = side1Length;
            Side2Length = side2Length;
            Side3Length = side3Length;
            Color = color;
        }

        public override double CalculateArea()
        {
            double HeronS = (Side1Length + Side2Length + Side3Length) / 2;
            return Math.Sqrt(HeronS * (HeronS - Side1Length) * (HeronS - Side2Length) * (HeronS - Side3Length));
        }

        public string GetColor()
        {
            return Color;
        }

        public override string ToString()
        {
            return $"This {Name} has area {CalculateArea():N} and is the color {GetColor()}";
        }
    }
}
