using System;

namespace IndoorNav
{
    class PointTime
    {
        public Point Point { get; set; }
        public DateTime Time { get; set; }

        public PointTime(Point point, DateTime time)
        {
            Point = point;
            Time = time;
        }
    }
}
