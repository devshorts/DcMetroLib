using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class BusRouteDetails : MetroDataItemBase
    {
        public int DirectionNum { get; set; }

        public string DirectionText { get; set; }

        [XmlArray("Shape")]
        [XmlArrayItem("ShapePoint", typeof(BusRoutePoint))]
        public List<BusRoutePoint> Positions { get; set; }

        [XmlArray("Stops")]
        [XmlArrayItem("Stop", typeof(BusStop))]
        public List<BusStop> BusStops { get; set; }

        public String TripHeadsign { get; set; }
    }
}
