using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DcMetroLib.Common;
using DcMetroLib.MetroService;

namespace DcMetroLib.Data.Containers
{
    [Serializable]
    [XmlRoot(ElementName = "LinesResp", Namespace = "http://www.wmata.com"), XmlType("LinesResp")]
    public class LinesContainer : MetroDataItemBase
    {
        [XmlArray("Lines")]
        [XmlArrayItem("Line", typeof(LineInfo))]
        public List<LineInfo> Lines { get; set; }

        internal override void Process()
        {
            Lines.ForEach(l=>l.Process());
        }
    }
}
