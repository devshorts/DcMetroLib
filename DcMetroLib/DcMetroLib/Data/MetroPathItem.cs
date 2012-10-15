using System;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class MetroPathItem : MetroDataItemBase
    {
        [XmlElement("DistanceToPrev")]
        public int DistanceFromPreviousStationFeet { get; set; }

        [XmlElement("LineCode")]
        public String LineCodeRaw { get; set; }

        [XmlIgnore]
        public LineCodeType LineCode { get; set; }

        [XmlElement("SeqNum")]
        public int SequenceNumber { get; set; }

        internal override void Process()
        {
            LineCode = LineCodeUtil.FromString(LineCodeRaw);
        }
    }
}
