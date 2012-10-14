using System.Xml.Linq;

namespace DcMetroLib.Interfaces
{
    public interface IMetroData
    {
        /// <summary>
        /// Takes an XML element and populates this objects MetroElement methods with 
        /// the related xml fields
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="df"></param>
        /// <returns></returns>
        object Decode(XElement elem, XNamespace df);
    }
}
