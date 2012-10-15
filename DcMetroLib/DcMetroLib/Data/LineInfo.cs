using System;
using System.Xml.Serialization;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    [Serializable]
    public class LineInfo : MetroDataItemBase
    {
        [XmlElement]
        public string DisplayName { get; set; }

        [XmlElement]
        public string EndStationCode { get; set; }

        [XmlElement]
        public string InternalDestination1 { get; set; }

        [XmlElement]
        public string InternalDestination2 { get; set; }

        [XmlElement("LineCode")]
        public string LineCodeRaw { get; set; }

        [XmlIgnore]
        public LineCodeType LineCode { get; set; }

        [XmlElement]
        public string StartStationCode { get; set; }

        internal override void Process()
        {
            LineCode = LineCodeUtil.FromString(LineCodeRaw);
        }
    }
}
