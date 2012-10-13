using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DcMetroLib.Common;

namespace DcMetroLib.Data
{
    public class RailIncidentData : XmlDecoder
    {
        /*
         * <DateUpdated>2010-07-29T14:21:18</DateUpdated>
      <DelaySeverity>NA</DelaySeverity>
      <Description>Friendship Heights station has been closed due to a power problem. Shuttle service has been requested.</Description>
      <EmergencyText i:nil="true" />
      <EndLocationFullName i:nil="true" />
      <IncidentID>72081</IncidentID>
      <IncidentType>Station Incident</IncidentType>
      <LinesAffected>RD;</LinesAffected>
      <PassengerDelay>0</PassengerDelay>
      <StartLocationFullName>Friendship Heights</StartLocationFullName>
         */

        [MetroElement]
        public DateTime DateUpdated { get; set; }

        [MetroElement]
        public String DelaySeverity { get; set; }

        [MetroElement]
        public String Description { get; set; }

        [MetroElement]
        public String EmergencyText { get; set; }

        [MetroElement]
        public String EndLocationFullName { get; set; }

        [MetroElement]
        public String IncidentID { get; set; }

        [MetroElement]
        public String IncidentType { get; set; }

        [MetroElement]
        public String LinesAffected { get; set; }

        [MetroElement(XmlName = "PassengerDelay")]
        public int PassengerDelayMinutes { get; set; }

        [MetroElement]
        public string StartLocationFullName { get; set; }
    }
}
