using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "StationEntrancesResp", Namespace = "http://www.wmata.com")]
    public class StationEntranceContainer : MetroDataItemBase
    {
        [XmlArray("Entrances")]
        [XmlArrayItem("StationEntrance", typeof(StationEntrance))]
        public List<StationEntrance> StationEntrances { get; set; }

        internal override void Process()
        {
            StationEntrances.ForEach(l => l.Process());
        }
    }
}
