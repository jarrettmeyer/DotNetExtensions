using System;
using System.Xml.Linq;

namespace FusionAlliance.DotNetExtensions.Common.Xml
{
    public static class XmlExtenstions
    {
        public static XDocument ToXml<T>(this T source)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return XmlUtil.ObjectToXml(source);
        }
    }
}