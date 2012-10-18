using System;
using System.Xml.Serialization;

namespace DcMetroLib.Data
{
    [Serializable]
    public class BusStopTimes : MetroDataItemBase
    {
        public int StopID { get; set; }

        public string StopName { get; set; }

        [XmlElement("StopSeq")]
        public int StopSequence { get; set; }

        [XmlElement("Time")]
        public DateTime StopTime { get; set; }
    }
}
