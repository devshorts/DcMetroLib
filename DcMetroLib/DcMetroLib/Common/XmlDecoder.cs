using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using DcMetroLib.Data;
using DcMetroLib.Interfaces;
using DcMetroLib.MetroService;

namespace DcMetroLib.Common
{
    public class XmlDecoder : IMetroData
    {
        public XmlDecoder()
        {
        }

        public object Decode(XElement elem, XNamespace df)
        {
            // get all the public properties
            var publicProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance |
                                                           BindingFlags.OptionalParamBinding |
                                                           BindingFlags.CreateInstance)
                .Where(prop => prop.GetCustomAttributes(typeof (MetroElement), false) != null);

            // methods tagged with MetroElement
            var methods = publicProperties;

            foreach(PropertyInfo method in methods)
            {
                var xmlElementName = MappedNameForMethod(method);

                if(xmlElementName == null)
                {
                    continue;
                }

                var value = elem.Element(df + xmlElementName).Value;

                method.SetValue(this, Convert.ChangeType(value, method.PropertyType, null), null);
            }

            return this;
        }

        private string MappedNameForMethod(PropertyInfo method)
        {
            var metroElementTag = method.GetCustomAttributes(typeof (MetroElement), false).FirstOrDefault() as MetroElement;

            if(metroElementTag != null)
            {
                var xmlName = metroElementTag.XmlName;
                if(String.IsNullOrEmpty(xmlName))
                {
                    return method.Name;
                }
                return xmlName;
            }
            return null;
        }
    }
}
