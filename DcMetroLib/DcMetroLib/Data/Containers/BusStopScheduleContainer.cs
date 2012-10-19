using System.Collections.Generic;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "StopScheduleInfo", Namespace = "http://www.wmata.com")]
    public class BusStopScheduleContainer : MetroDataItemBase
    {
        [XmlArray("ScheduleArrivals")]
        [XmlArrayItem("StopScheduleArrival", typeof(StopScheduleArrival))]
        public List<StopScheduleArrival> ScheduledArrivals { get; set; }

        public BusStop Stop { get; set; }
    }
}
