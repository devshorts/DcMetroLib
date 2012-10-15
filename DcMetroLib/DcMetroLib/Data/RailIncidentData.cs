using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class RailIncidentData : MetroDataItemBase
    {
        [XmlElement]
        public DateTime DateUpdated { get; set; }

        [XmlElement]
        public String DelaySeverity { get; set; }

        [XmlElement]
        public String Description { get; set; }

        [XmlElement]
        public String EmergencyText { get; set; }

        [XmlElement]
        public String EndLocationFullName { get; set; }

        [XmlElement]
        public String IncidentID { get; set; }

        [XmlElement]
        public String IncidentType { get; set; }

        [XmlElement(ElementName = "LinesAffected")]
        public String LinesAffectedRaw { get; set; }

        [XmlIgnore]
        public List<LineCodeType> LinesAffected { get; set; }

        [XmlElement(ElementName = "PassengerDelay")]
        public int PassengerDelayMinutes { get; set; }

        [XmlElement]
        public string StartLocationFullName { get; set; }

        internal override void Process()
        {
             LinesAffected = LineCodeUtil.FromDelimitedString(LinesAffectedRaw, ";");
        }
    }
}
