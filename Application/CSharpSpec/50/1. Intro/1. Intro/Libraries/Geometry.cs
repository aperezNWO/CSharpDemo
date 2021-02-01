using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Intro.Geometry
{
    internal struct TPoint
    {
        public int x, y;

        public TPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("Constructor");
        }
        ~Point()
        {
            Console.WriteLine("Destructor");
        }
    }

    internal class Point3D : Point
    {
        internal int z;
        internal protected Point3D(int x, int y, int z) : base(x, y)
        {
            this.z = z;
        }
    }

    internal class TPoint<TFirst, TSecond>
    {
        internal TFirst x;
        internal TSecond y;

        public TPoint()
        {

        }
        public TPoint(TFirst x, TSecond y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("Constructor");
        }
        ~TPoint()
        {
            Console.WriteLine("Destructor");
        }
    }

    internal class Box
    {
        private double length;    // Length of a box
        private double breadth;   // Breadth of a box
        private double height;    // Height of a box    
        public double Volume
        {
            get { return this.length * this.breadth * this.height; }
        }
        public Box()
        {

        }
        public Box(double aLength, double aBreadth, double aHeight)
        {
            this.length = aLength;
            this.breadth = aBreadth;
            this.height = aHeight;
        }
        public static Box operator +(Box b, Box c)
        {
            Box box = new Box();
            box.length = b.length + c.length;
            box.breadth = b.breadth + c.breadth;
            box.height = b.height + c.height;
            return box;
        }
        public override string ToString()
        {
            return String.Format("Dimentions : ({0}, {1}, {2}), Volume : {3}", length, breadth, height, Volume);
        }
    }

    internal class Color
    {
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Blue = new Color(0, 0, 255);
        private byte r, g, b;
        public Color(byte r = 0, byte g = 0, byte b = 0)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public override string ToString()
        {
            return String.Format("Color Values : ({0}, {1}, {2})", this.r, this.b, this.b);
        }
    }

    public enum TColor
    {
        Red   = 0,
        Green = 1,
        Blue  = 2
    };

    public class TestColor
    {
        public static void Print(TColor color)
        {
            switch (color)
            {
                case TColor.Red:
                    Console.WriteLine("Red");
                    break;
                case TColor.Green:
                    Console.WriteLine("Green");
                    break;
                case TColor.Blue:
                    Console.WriteLine("Blue");
                    break;
                default:
                    Console.WriteLine("Unknown color");
                    break;
            }
        }
    }
}
