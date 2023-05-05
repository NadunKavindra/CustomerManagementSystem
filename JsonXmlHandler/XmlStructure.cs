using System.Xml;

namespace JsonXmlHandler
{
    public static class XmlStructure
    {
        public static string treeView = "";

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

        public static string PrintXmlTreeStructure(XmlNode xmlNode, string prefix = "", bool isLast = true)
        {
            treeView += prefix;

            if (isLast)
            {
                treeView += "└─";
                prefix += "  ";
            }
            else
            {
                treeView += "├─";
                prefix += "│ ";
            }

            treeView += xmlNode.Name.Contains("#") ? ("(" + xmlNode.Value + ")" + "\n") : (xmlNode.Name + "\n");

            XmlNodeList children = xmlNode.ChildNodes;
            for (int i = 0; i < children.Count; i++)
            {
                PrintXmlTreeStructure(children[i], prefix, i == children.Count - 1);
            }

            return treeView;
        }

    }
}
