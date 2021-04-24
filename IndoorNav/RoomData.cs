using System.Linq;

namespace IndoorNav
{
    class RoomData
    {
        private static Point[] coords =
        {
            new Point(0, 3.3),
            new Point(0, 0.3),
            new Point(21, 0.23),
            new Point(20.8, 3.47),
            new Point(7.8, 0.67),
            new Point(12, 2.96)
        };

        public static Point GetCoordinates(int beaconId){
            return coords[beaconId - 1];
        }

        public static double GetEnvFactor(int id)
        {
            return 2;
        }

        public static int GetRoom(Point position)
        {
            if (position.X < 7.8)
            {
                return 3;
            }
            else if (position.X < 12)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public static int GetClosest(Point position)
        {
            double minDistance = double.MaxValue;
            int closest = 0;
            for(int i = 0; i < coords.Length; i++)
            {
                Point pt = coords[i];
                double distance = pt.Distance(position);
                if(distance < minDistance)
                {
                    closest = i;
                    minDistance = distance;
                }
            }
            return closest + 1;
        }
    }
}
