using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    [XmlRoot(ElementName = "Station", Namespace = "http://www.wmata.com")]
    public class StationInfo : MetroDataItemBase, IComparer<StationInfo>
    {
        [XmlElement]
        public String Code { get; set; }

        [XmlElement]
        public Double Lat { get; set; }

        [XmlElement("LineCode1")]
        public String LineCode1Raw { get; set; }

        [XmlElement("LineCode2")]
        public String LineCode2Raw { get; set; }

        [XmlElement("LineCode3")]
        public String LineCode3Raw { get; set; }

        [XmlElement("LineCode4")]
        public String LineCode4Raw { get; set; }

        [XmlIgnore]
        public LineCodeType LineCode1 { get; set; }

        [XmlIgnore]
        public LineCodeType LineCode2 { get; set; }

        [XmlIgnore]
        public LineCodeType LineCode3 { get; set; }

        [XmlIgnore]
        public LineCodeType LineCode4 { get; set; }

        [XmlElement]
        public Double Lon { get; set; }

        [XmlElement]
        public String Name { get; set; }

        [XmlElement]
        public String StationTogether1 { get; set; }

        [XmlElement]
        public String StationTogether2 { get; set; }

        internal override void Process()
        {
            LineCode1 = LineCodeUtil.FromString(LineCode1Raw);
            LineCode2 = LineCodeUtil.FromString(LineCode2Raw);
            LineCode3 = LineCodeUtil.FromString(LineCode3Raw);
            LineCode4 = LineCodeUtil.FromString(LineCode4Raw);
        }

        public int Compare(StationInfo x, StationInfo y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
