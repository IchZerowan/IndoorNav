using System;

namespace IndoorNav
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point() { }

        public double Distance(Point p2)
        {
            return Math.Sqrt(Math.Pow(X - p2.X, 2) + Math.Pow(X - p2.X, 2));
        }

        public Point Avg(Point p2)
        {
            return new Point((X + p2.X) / 2, (Y + p2.Y) / 2);
        }
    }
}
