using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "ElevatorIncidentsResp", Namespace = "http://www.wmata.com")]
    public class ElevatorIncidentsContainer : MetroDataItemBase
    {
        [XmlArray("ElevatorIncidents")]
        [XmlArrayItem("ElevatorIncident", typeof(ElevatorIncidentData))]
        public List<ElevatorIncidentData> ElevatorIncidents { get; set; }

        internal override void Process()
        {
            ElevatorIncidents.ForEach(l => l.Process());
        }
    }
}
