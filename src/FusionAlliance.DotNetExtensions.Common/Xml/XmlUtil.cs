using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FusionAlliance.DotNetExtensions.Common.Xml
{
    public static class XmlUtil
    {
        /// <summary>
        /// Converts the given object into an XML representation.
        /// </summary>
        public static XDocument ObjectToXml(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            XDocument target = new XDocument();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (XmlWriter writer = target.CreateWriter())
            {
                serializer.Serialize(writer, obj);
            }
            return target;
        }

        /// <summary>
        /// Converts the given XML to an object.
        /// </summary>
        public static T XmlToObject<T>(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            return XmlToObject<T>(XDocument.Parse(text));
        }

        /// <summary>
        /// Converts the given XML to an object.
        /// </summary>
        public static T XmlToObject<T>(XDocument xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (T));
            using (XmlReader reader = xml.CreateReader())
            {
                var target = serializer.Deserialize(reader);
                return (T)target;
            }
        }
    }
}
