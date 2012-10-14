using System.Xml.Linq;
using DcMetroLib.Common;
using DcMetroLib.Data;

namespace DcMetroLib.MetroService
{
    public class LineInfo : XmlDecoder
    {
        [MetroElement]
        public string DisplayName { get; set; }

        [MetroElement]
        public string EndStationCode { get; set; }

        [MetroElement]
        public string InternalDestination1 { get; set; }

        [MetroElement]
        public string InternalDestination2 { get; set; }

        [MetroElement(XmlName = "LineCode")]
        private string LineCodeRaw { get; set; }

        public LineCodeType LineCode { get; set; }

        [MetroElement]
        public string StartStationCode { get; set; }

        protected override void Process()
        {
            LineCode = LineCodeUtil.FromString(LineCodeRaw);
        }
    }
}
