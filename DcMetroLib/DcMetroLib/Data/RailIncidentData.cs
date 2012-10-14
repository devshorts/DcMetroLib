using System;
using System.Collections.Generic;
using System.Linq;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public class RailIncidentData : XmlDecoder
    {
        [MetroElement]
        public DateTime DateUpdated { get; set; }

        [MetroElement]
        public String DelaySeverity { get; set; }

        [MetroElement]
        public String Description { get; set; }

        [MetroElement]
        public String EmergencyText { get; set; }

        [MetroElement]
        public String EndLocationFullName { get; set; }

        [MetroElement]
        public String IncidentID { get; set; }

        [MetroElement]
        public String IncidentType { get; set; }

        [MetroElement(XmlName = "LinesAffected")]
        private String LinesAffectedRaw { get; set; }

        public List<LineCodeType> LinesAffected { get; set; }

        [MetroElement(XmlName = "PassengerDelay")]
        public int PassengerDelayMinutes { get; set; }

        [MetroElement]
        public string StartLocationFullName { get; set; }

        protected override void Process()
        {
             LinesAffected = LineCodeUtil.FromDelimitedString(LinesAffectedRaw, ";");
        }
    }
}
