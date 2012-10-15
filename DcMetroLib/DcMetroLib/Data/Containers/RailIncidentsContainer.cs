using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "IncidentsResp", Namespace = "http://www.wmata.com")]
    public class RailIncidentsContainer : MetroDataItemBase
    {
        [XmlArray("Incidents")]
        [XmlArrayItem("Incident", typeof(RailIncidentData))]
        public List<RailIncidentData> RailIncidents { get; set; }

        internal override void Process()
        {
            RailIncidents.ForEach(l => l.Process());
        }
    }
}
