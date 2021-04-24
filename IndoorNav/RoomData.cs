namespace IndoorNav
{
    class RoomData
    {
        private static Algorithm.Point[] coords =
        {
            new Algorithm.Point(3.3, 0),
            new Algorithm.Point(0.3, 0),
            new Algorithm.Point(0.23, 21),
            new Algorithm.Point(3.47, 20.8),
            new Algorithm.Point(0.67, 7.8),
            new Algorithm.Point(2.96, 12)
        };

        public static Algorithm.Point GetCoordinates(int beaconId){
            return coords[beaconId - 1];
        }

        public static double GetEnvFactor(int id)
        {
            return 2;
        }

        public static int GetSquare(Algorithm.Point position)
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
    }
}
