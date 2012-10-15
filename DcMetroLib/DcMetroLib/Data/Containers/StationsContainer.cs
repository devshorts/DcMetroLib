using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DcMetroLib.Common;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "StationsResp", Namespace = "http://www.wmata.com")]
    public class StationsContainer : MetroDataItemBase
    {
        [XmlArray("Stations")]
        [XmlArrayItem("Station", typeof(StationInfo))]
        public List<StationInfo> Stations { get; set; }

        internal override void Process()
        {
            Stations.ForEach(l => l.Process());
        }
    }
}
