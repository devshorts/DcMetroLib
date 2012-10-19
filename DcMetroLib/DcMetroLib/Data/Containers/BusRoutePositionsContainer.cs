using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "RouteDetailsInfo", Namespace = "http://www.wmata.com")]
    public class BusRoutePositionsContainer : MetroDataItemBase
    {
        public BusRouteDetails Direction0 { get; set; }

        public BusRouteDetails Direction1 { get; set; }

        public String Name { get; set; }

        public String RouteID { get; set; }
    }
}
