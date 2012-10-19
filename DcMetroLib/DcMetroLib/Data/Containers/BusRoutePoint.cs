using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    public class BusRoutePoint : MetroDataItemBase
    {
        public double Lat { get; set; }

        public double Lon { get; set; }

        [XmlElement("SeqNum")]
        public int SequenceNumber { get; set; }
    }
}
