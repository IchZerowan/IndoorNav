﻿using System;

namespace IndoorNav
{
    public class PointData
    {
        //,device_name,mac_addr,eddystone_instance_id,rssi,timestamp
        public int id { get; set; }
        public double rssi { get; set; }
        public DateTime timestamp { get; set; }
    }
}
