using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public class StationInfo : XmlDecoder, IComparer<StationInfo>
    {
        [MetroElement]
        public String Code { get; set; }

        [MetroElement]
        public Double Lat { get; set; }

        [MetroElement(XmlName = "LineCode1")]
        private String LineCode1Raw { get; set; }

        [MetroElement(XmlName = "LineCode2")]
        private String LineCode2Raw { get; set; }

        [MetroElement(XmlName = "LineCode3")]
        private String LineCode3Raw { get; set; }

        [MetroElement(XmlName = "LineCode4")]
        private String LineCode4Raw { get; set; }

        public LineCodeType LineCode1 { get; set; }
        public LineCodeType LineCode2 { get; set; }
        public LineCodeType LineCode3 { get; set; }
        public LineCodeType LineCode4 { get; set; }

        [MetroElement]
        public Double Lon { get; set; }

        [MetroElement]
        public String Name { get; set; }

        [MetroElement]
        public String StationTogether1 { get; set; }

        [MetroElement]
        public String StationTogether2 { get; set; }

        protected override void Process()
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
