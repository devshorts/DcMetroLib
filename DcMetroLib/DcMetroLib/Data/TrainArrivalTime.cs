using System;
using System.Xml.Linq;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public class TrainArrivalTime :XmlDecoder
    {
        [MetroElement]
        public String Car { get; set; }

        [MetroElement]
        public String Destination { get; set; }

        [MetroElement]
        public String DestinationCode { get; set; }

        [MetroElement]
        public String DestinationName { get; set; }

        [MetroElement]
        public String Group { get; set; }

        [MetroElement]
        public String Line { get; set; }

        [MetroElement]
        public String LocationCode { get; set; }

        [MetroElement]
        public String LocationName { get; set; }

        [MetroElement]
        public String Min { get; set; }
    }
}
