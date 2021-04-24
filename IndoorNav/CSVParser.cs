
using IndoorNav;
using System;
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
                sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    PointData pd = new PointData();
                    string[] splitted = line.Split(',');
                    pd.id = Convert.ToInt32(splitted[3]);
                    pd.rssi = Convert.ToInt32(splitted[4]);
                    pd.timestamp = splitted[5];

                    data.Add(pd);
                }
            }

            return data;
        }
    }
}
