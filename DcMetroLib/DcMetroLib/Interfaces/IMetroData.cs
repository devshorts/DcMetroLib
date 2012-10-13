using System.Xml.Linq;

namespace DcMetroLib.Interfaces
{
    public interface IMetroData
    {
        object Decode(XElement elem, XNamespace df);
    }
}
