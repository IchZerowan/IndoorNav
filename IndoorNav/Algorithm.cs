using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNav
{
    class Algorithm
    {
        struct Point
        {
            double X { get; set; }
            double Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        Point Trilateration(PointData pd1, PointData pd2, PointData pd3)
        {
            return new Point(0, 0);
        }
    }
}
