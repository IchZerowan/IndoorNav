using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IndoorNav
{
    public class PointData
    {
        //,device_name,mac_addr,eddystone_instance_id,rssi,timestamp

        public string FirstTimeStamp { get; set; }
        public string device_name { get; set; }
        public string mac_addr { get; set; }
        public string eddystone_instance_id { get; set; }
        public string rssi { get; set; }
        public string timestamp { get; set; }

    }
}
