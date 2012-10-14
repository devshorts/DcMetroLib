using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using DcMetroLib.Data;
using DcMetroLib.Interfaces;

namespace DcMetroLib.Common
{
    public class XmlDecoder : IMetroData
    {
        public XmlDecoder()
        {
        }

        public object Decode(XElement elem, XNamespace df)
        {
            // get all the properties
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | 
                                                           BindingFlags.OptionalParamBinding |
                                                           BindingFlags.CreateInstance)
                .Where(prop => prop.GetCustomAttributes(typeof (MetroElement), false) != null);

            // methods tagged with MetroElement
            var methods = properties;

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

            Process();

            return this;
        }

        /// <summary>
        /// Each object can post process its data
        /// </summary>
        protected virtual void Process()
        {
            // for overriding to process raw strings into typed objects
        }

        private string MappedNameForMethod(PropertyInfo method)
        {
            var metroElementTag = GetMetroElement(method);

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

        private MetroElement GetMetroElement(PropertyInfo method)
        {
            return method.GetCustomAttributes(typeof (MetroElement), false).FirstOrDefault() as MetroElement;
        }
    }
}
