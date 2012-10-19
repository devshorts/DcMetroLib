using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.Data.Containers;

namespace DcMetroLib.Data
{
    [Serializable]
    public class BusStop : MetroDataItemBase
    {
        public Double Lat { get; set; }

        public Double Lon { get; set; }

        public String Name { get; set; }

        [XmlArrayItem(typeof(String), Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<String> Routes { get; set; }

        public int StopID { get; set; }
    }
}
