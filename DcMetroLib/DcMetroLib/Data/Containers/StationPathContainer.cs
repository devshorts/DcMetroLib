using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DcMetroLib.Common;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "PathResp", Namespace = "http://www.wmata.com")]
    public class StationPathContainer : MetroDataItemBase
    {
        [XmlArray("Path")]
        [XmlArrayItem("MetroPathItem", typeof(MetroPathItem))]
        public List<MetroPathItem> MetroPathItems { get; set; }

        internal override void Process()
        {
            MetroPathItems.ForEach(l => l.Process());
        }
    }
}
