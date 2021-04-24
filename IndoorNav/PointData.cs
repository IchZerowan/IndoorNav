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
        public int id { get; set; }
        public int rssi { get; set; }
        public string timestamp { get; set; }
    }
}
