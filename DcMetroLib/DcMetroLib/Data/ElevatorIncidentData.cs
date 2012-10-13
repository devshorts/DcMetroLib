using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public class ElevatorIncidentData : XmlDecoder
    {
        [MetroElement(XmlName = "DateOutOfServ")]
        public DateTime DateWhenOutOfService { get; set; }

        [MetroElement]
        public DateTime DateUpdated { get; set; }

        [MetroElement]
        public int DisplayOrder { get; set; }

        [MetroElement]
        public String LocationDescription { get; set; }

        [MetroElement]
        public String StationCode { get; set; }

        [MetroElement]
        public String StationName { get; set; }

        [MetroElement]
        public int SymptomCode { get; set; }

        [MetroElement]
        public String SymptomDescription { get; set; }

        [MetroElement(XmlName = "TimeOutOfService")]
        public int TimeOutOfServiceMinutes { get; set; }

        [MetroElement]
        public string UnitName { get; set; }

        [MetroElement]
        public String UnitStatus { get; set; }

        [MetroElement]
        public string UnitType { get; set; }
    }
}
