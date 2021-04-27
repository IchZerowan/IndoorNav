using System;
using System.Collections.Generic;

namespace IndoorNav
{
    class Algorithm
    {
        public const double MEASURED_POWER = -51;

        public static Point Trilateration(PointData pd1, PointData pd2, PointData pd3)
        {
            Point pc1 = RoomData.GetCoordinates(pd1.id);
            Point pc2 = RoomData.GetCoordinates(pd2.id);
            Point pc3 = RoomData.GetCoordinates(pd3.id);

            List<Point> results = new List<Point>();

            double d1 = DistanceFromRssi(pd1);
            double d2 = DistanceFromRssi(pd2);
            double d3 = DistanceFromRssi(pd3);

            GetCircleIntersections(results, pc1, pc2, d1, d2);
            GetCircleIntersections(results, pc2, pc3, d2, d3);
            GetCircleIntersections(results, pc1, pc3, d1, d3);

            double minDistance = double.MaxValue;
            Point bestPoint = null;
            foreach(Point p1 in results)
            {
                foreach (Point p2 in results)
                {
                    if(p1 != p2)
                    {
                        double distance = p1.Distance(p2);
                        if(distance < minDistance)
                        {
                            bestPoint = p1.Avg(p2);
                            distance = minDistance;
                        }
                    }
                }
            }
            
            return bestPoint;
        }

        public static double DistanceFromRssi(PointData pd)
        {
            return Math.Pow(10, (MEASURED_POWER - pd.rssi) / (10 * RoomData.GetEnvFactor(pd.id)));
        }

        public static void GetCircleIntersections(List<Point> results, Point c1, Point c2, double r1, double r2)
        {
            (double x1, double y1, double x2, double y2) = (c1.X, c1.Y, c2.X, c2.Y);
            double d = c1.Distance(c2);

            if (Math.Abs(r1 - r2) > d || d > r1 + r2) 
                return; 

            var dsq = d * d;
            var (r1sq, r2sq) = (r1 * r1, r2 * r2);
            var r1sq_r2sq = r1sq - r2sq;
            var a = r1sq_r2sq / (2 * dsq);
            var c = Math.Sqrt(2 * (r1sq + r2sq) / dsq - (r1sq_r2sq * r1sq_r2sq) / (dsq * dsq) - 1);

            var fx = (x1 + x2) / 2 + a * (x2 - x1);
            var gx = c * (y2 - y1) / 2;

            var fy = (y1 + y2) / 2 + a * (y2 - y1);
            var gy = c * (x1 - x2) / 2;

            var i1 = new Point(fx + gx, fy + gy);
            var i2 = new Point(fx - gx, fy - gy);

            results.Add(i1);
            results.Add(i2);
        }
    }
}
