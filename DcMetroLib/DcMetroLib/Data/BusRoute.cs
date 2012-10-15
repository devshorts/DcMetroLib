using System;
using System.Xml.Serialization;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    [Serializable]
    public class BusRoute : MetroDataItemBase
    {
        [XmlElement]
        public String Name { get; set; }

        [XmlElement]
        public string RouteID { get; set; }
    }
}
