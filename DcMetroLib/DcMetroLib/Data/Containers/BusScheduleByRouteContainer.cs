using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "RouteScheduleInfo", Namespace = "http://www.wmata.com")]
    public class BusScheduleByRouteContainer : MetroDataItemBase
    {
        [XmlArray("Direction0")]
        [XmlArrayItem("Trip", typeof(BusTrip))]
        public List<BusTrip> Direction0Trips { get; set; }

        [XmlArray("Direction1")]
        [XmlArrayItem("Trip", typeof(BusTrip))]
        public List<BusTrip> Direction1Trips { get; set; }
        
        public String Name { get; set; }
    }
}
