using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [Serializable]
    public class BusTrip : MetroDataItemBase
    {
        public int DirectionNum { get; set; }

        public DateTime EndTime { get; set; }

        public String RouteID { get; set; }

        public DateTime StartTime { get; set; }

        [XmlArray("StopTimes")]
        [XmlArrayItem("StopTime", typeof(BusStopTimes))]
        public List<BusStopTimes> StopTimes { get; set; }
    }
}
