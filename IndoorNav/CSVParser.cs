
using IndoorNav;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace IndoorNav
{
    public class CSVParser
    {
        public static List<PointData> ReadCSV (string pathToFile)
        {
            List<PointData> data = new List<PointData>();

            using (StreamReader sr = new StreamReader(pathToFile))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    PointData pd = new PointData();
                    pd.FirstTimeStamp = line.Split(',')[0];
                    pd.device_name = line.Split(',')[1];
                    pd.mac_addr = line.Split(',')[2];
                    pd.eddystone_instance_id = line.Split(',')[3];
                    pd.rssi = line.Split(',')[4];
                    pd.timestamp = line.Split(',')[5];

                    data.Add(pd);
                }
            }

            return data;
        }
    }
}
