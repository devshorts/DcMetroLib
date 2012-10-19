using System.Collections.Generic;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "RoutesResp", Namespace = "http://www.wmata.com")]
    public class BusRoutesContainer : MetroDataItemBase
    {
        [XmlArray("Routes")]
        [XmlArrayItem("Route", typeof(BusRoute))]
        public List<BusRoute> BusRoutes { get; set; }

        internal override void Process()
        {
            BusRoutes.ForEach(l => l.Process());
        }
    }
}
