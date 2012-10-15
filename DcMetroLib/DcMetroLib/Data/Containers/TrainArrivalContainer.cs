using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DcMetroLib.Data.Containers
{
    [XmlRoot(ElementName = "AIMPredictionResp", Namespace = "http://www.wmata.com")]
    public class TrainArrivalContainer : MetroDataItemBase
    {
        [XmlArray("Trains")]
        [XmlArrayItem("AIMPredictionTrainInfo", typeof(TrainArrivalTime))]
        public List<TrainArrivalTime> TrainArrivalTimes { get; set; }

        internal override void Process()
        {
            TrainArrivalTimes.ForEach(l => l.Process());
        }
    }
}
