using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace IndoorNav.Models
{
    public class PointData
    {
        //,device_name,mac_addr,eddystone_instance_id,rssi,timestamp

        [Index(0)]
        public string FirstTimeStamp { get; set; }
        [Index(1)]
        public string device_name { get; set; }
        [Index(2)]
        public string mac_addr { get; set; }
        [Index(3)]
        public string eddystone_instance_id { get; set; }
        [Index(4)]
        public string rssi { get; set; }
        [Index(5)]
        public string timestamp { get; set; }

    }
}
