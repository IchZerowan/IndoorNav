using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNav
{
    class RoomData
    {
        public Algorithm.Point GetCoordinates(int beaconId){
            Algorithm.Point beaconPoint = new Algorithm.Point(0, 0);
            if (beaconId == 1)
            {
                beaconPoint = new Algorithm.Point(3.3, 0);
            }
            else if (beaconId == 2)
            {
                beaconPoint = new Algorithm.Point(0.3, 0);
            }
            else if (beaconId == 3)
            {
                beaconPoint = new Algorithm.Point(0.23, 21);
            }
            else if (beaconId == 4)
            {
                beaconPoint = new Algorithm.Point(3.47, 20.8);
            }
            else if (beaconId == 5)
            {
                beaconPoint = new Algorithm.Point(0.67, 7.8);
            }
            else if (beaconId == 6)
            {
                beaconPoint = new Algorithm.Point(2.96, 12);
            }
            return beaconPoint;
        }
    }
}
