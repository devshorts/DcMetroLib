using System;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public class MetroPathItem : XmlDecoder
    {
        [MetroElement(XmlName = "DistanceToPrev")]
        public int DistanceFromPreviousStationFeet { get; set; }

        [MetroElement(XmlName = "LineCode")]
        private String LineCodeRaw { get; set; }

        public LineCodeType LineCode { get; set; }

        [MetroElement(XmlName = "SeqNum")]
        public int SequenceNumber { get; set; }

        protected override void Process()
        {
            LineCode = LineCodeUtil.FromString(LineCodeRaw);
        }
    }
}
