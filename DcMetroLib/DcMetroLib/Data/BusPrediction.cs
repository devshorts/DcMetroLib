using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data
{
    public class BusPrediction : MetroDataItemBase
    {
        /*
         * <DirectionNum>0</DirectionNum>
      <DirectionText>East to Stadium - Armory</DirectionText>
      <Minutes>11</Minutes>
      <RouteID>96</RouteID>
      <VehicleID>2162</VehicleID>*/

        public int DirectionNum { get; set; }

        public String DirectionText { get; set; }

        [XmlElement("Minutes")]
        public double MinutesToArrival { get; set; }

        public String RouteID { get; set; }

        public int VehicleID { get; set; }
    }
}
