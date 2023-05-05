using System.Xml;

namespace JsonXmlHandler
{
    public static class XmlStructure
    {
        //Print xml in prettier way
        public static string GetXmlString(XmlDocument xmlDoc)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\n";
            settings.NewLineHandling = NewLineHandling.Replace;

            using (var stringWriter = new System.IO.StringWriter())
            using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
            {
                xmlDoc.WriteTo(writer);
                writer.Flush();
                return stringWriter.ToString();
            }
        }
    }
}
