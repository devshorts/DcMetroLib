using System;
using System.Xml.Linq;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public class StationEntrance : XmlDecoder
    {
        [MetroElement]
        public string Description { get; set; }

        [MetroElement]
        public string ID { get; set; }

        [MetroElement]
        public Double Lat { get; set; }

        [MetroElement]
        public Double Lon { get; set; }

        [MetroElement]
        public string Name { get; set; }

        [MetroElement]
        public string StationCode1 { get; set; }

        [MetroElement]
        public string StationCode2 { get; set; }
    }
}
