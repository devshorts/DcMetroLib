using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "BusPositionsResp", Namespace = "http://www.wmata.com")]
    public class BusPositionsContainer : MetroDataItemBase
    {
        [XmlArray("BusPositions")]
        [XmlArrayItem("BusPosition", typeof(BusPosition))]
        public List<BusPosition> BusPositions { get; set; }
    }
}
