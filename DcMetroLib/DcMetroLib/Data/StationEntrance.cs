using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class StationEntrance : MetroDataItemBase
    {
        [XmlElement]
        public string Description { get; set; }

        [XmlElement]
        public string ID { get; set; }

        [XmlElement]
        public Double Lat { get; set; }

        [XmlElement]
        public Double Lon { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string StationCode1 { get; set; }

        [XmlElement]
        public string StationCode2 { get; set; }
    }
}
