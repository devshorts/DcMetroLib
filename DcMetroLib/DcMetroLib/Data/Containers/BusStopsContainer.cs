using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DcMetroLib.MetroService;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "StopsResp", Namespace = "http://www.wmata.com")]
    public class BusStopsContainer : MetroDataItemBase
    {
        [XmlArray("Stops")]
        [XmlArrayItem("Stop", typeof(BusStops))]
        public List<BusStops> BusStops { get; set; }

        internal override void Process()
        {
            BusStops.ForEach(l => l.Process());
        }
    }
}
