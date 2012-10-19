using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "NextBusResponse", Namespace = "http://www.wmata.com")]
    public class BusStopPredictionContainer : MetroDataItemBase
    {
        [XmlArray("Predictions")]
        [XmlArrayItem("NextBusPrediction", typeof(BusPrediction))]
        public List<BusPrediction> BusPredictions { get; set; }

        public String StopName { get; set; }
    }
}
