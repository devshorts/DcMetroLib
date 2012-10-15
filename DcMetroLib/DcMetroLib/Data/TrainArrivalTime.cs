using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class TrainArrivalTime : MetroDataItemBase
    {
        [XmlElement]
        public String Car { get; set; }

        [XmlElement]
        public String Destination { get; set; }

        [XmlElement]
        public String DestinationCode { get; set; }

        [XmlElement]
        public String DestinationName { get; set; }

        [XmlElement]
        public String Group { get; set; }

        [XmlElement("Line")]
        public String LineRaw { get; set; }

        [XmlIgnore]
        public LineCodeType Line { get; set; }

        [XmlElement]
        public String LocationCode { get; set; }

        [XmlElement]
        public String LocationName { get; set; }

        [XmlElement]
        public String Min { get; set; }

        internal override void Process()
        {
            Line = LineCodeUtil.FromString(LineRaw);
        }
    }
}
