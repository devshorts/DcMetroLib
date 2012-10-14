using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    class MetroPathItem : XmlDecoder
    {
        [MetroElement(XmlName = "DistanceToPrev")]
        public int DistanceFromPreviousStationFeet { get; set; }

        [MetroElement(XmlName = "LineCode")]
        private String LineCodeRaw { get; set; }

        public LineCodeType LineCode { get; set; }

        [MetroElement]
        public int SequenceNumber { get; set; }

        protected override void Process()
        {
            LineCode = LineCodeUtil.FromString(LineCodeRaw);
        }
    }
}
