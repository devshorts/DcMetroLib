using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data
{
    [Serializable]
    public class BusPosition : MetroDataItemBase
    {
        [XmlElement("DateTime")]
        public DateTime LastBusReport { get; set; }

        [XmlElement("Deviation")]
        public double DeviationFromScheduleMinutes { get; set; }

        public String DirectionText { get; set; }

        public Double Lat { get; set; }

        public Double Lon { get; set; }

        public String RouteID { get; set; }

        public String TripHeadsign { get; set; }

        public String TripID { get; set; }

        public DateTime TripStartTime { get; set; }

        public int VehicleID { get; set; }
    }
}
