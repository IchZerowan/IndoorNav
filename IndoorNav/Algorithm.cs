using System;

namespace IndoorNav
{
    class Algorithm
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
        }

        Point Trilateration(PointData pd1, PointData pd2, PointData pd3)
        {
            Point pc1 = new Point(0, 0);
            Point pc2 = new Point(0, 0);
            Point pc3 = new Point(0, 0);

            
            return new Point(0, 0);
        }

        public static Point[] GetCircleIntersections(Point c1, Point c2, double r1, double r2)
        {
            (double x1, double y1, double x2, double y2) = (c1.X, c1.Y, c2.X, c2.Y);
            double d = c1.Distance(c2);

            if (!(Math.Abs(r1 - r2) <= d && d <= r1 + r2)) { return new Point[0]; }

            // Intersections i1 and possibly i2 exist
            var dsq = d * d;
            var (r1sq, r2sq) = (r1 * r1, r2 * r2);
            var r1sq_r2sq = r1sq - r2sq;
            var a = r1sq_r2sq / (2 * dsq);
            var c = Math.Sqrt(2 * (r1sq + r2sq) / dsq - (r1sq_r2sq * r1sq_r2sq) / (dsq * dsq) - 1);

            var fx = (x1 + x2) / 2 + a * (x2 - x1);
            var gx = c * (y2 - y1) / 2;

            var fy = (y1 + y2) / 2 + a * (y2 - y1);
            var gy = c * (x1 - x2) / 2;

            var i1 = new Point((float)(fx + gx), (float)(fy + gy));
            var i2 = new Point((float)(fx - gx), (float)(fy - gy));

            return new Point[] { i1, i2 };
        }
    }
}
