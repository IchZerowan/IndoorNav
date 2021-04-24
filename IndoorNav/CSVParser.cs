using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                    pd.rssi = Convert.ToDouble(splitted[4].Replace('.', ','));
                    pd.timestamp = DateTime.ParseExact(splitted[5], "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

                    data.Add(pd);
                }
            }

            data.Sort((pd1, pd2) => pd1.timestamp.CompareTo(pd2.timestamp));

            return data;
        }
    }
}
