using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class BusStops : MetroDataItemBase
    {
        [XmlElement]
        public Double Lat { get; set; }

        [XmlElement]
        public Double Lon { get; set; }

        [XmlElement]
        public String Name { get; set; }

        [XmlArray("Routes")]
        [XmlArrayItem(typeof(String))]
        public List<String> Routes { get; set; }

        [XmlElement]
        public int StopID { get; set; }
    }
}
