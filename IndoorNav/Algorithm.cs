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
            float X { get; set; }
            float Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        Point Trilateration(PointData pd1, PointData pd2, PointData pd3)
        {
            return null;
        }
    }
}
