using System;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class ElevatorIncidentData : MetroDataItemBase
    {
        [XmlElement("DateOutOfServ")]
        public DateTime DateWhenOutOfService { get; set; }

        [XmlElement]
        public DateTime DateUpdated { get; set; }

        [XmlElement]
        public int DisplayOrder { get; set; }

        [XmlElement]
        public String LocationDescription { get; set; }

        [XmlElement]
        public String StationCode { get; set; }

        [XmlElement]
        public String StationName { get; set; }

        [XmlElement]
        public int SymptomCode { get; set; }

        [XmlElement]
        public String SymptomDescription { get; set; }

        [XmlElement("TimeOutOfService")]
        public int TimeOutOfServiceMinutes { get; set; }

        [XmlElement]
        public string UnitName { get; set; }

        [XmlElement]
        public String UnitStatus { get; set; }

        [XmlElement]
        public string UnitType { get; set; }
    }
}
