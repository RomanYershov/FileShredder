using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace FShredder.Bll.Utils
{
    public class XmlParser
    {
        public static List<string> Parse(string path)
        {
            List<string> resultList = new List<string>();
            XmlDocument xDoc = new XmlDocument();
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Logger.Error($"Файл \"{fileInfo.Name}\" не существует в данном расположении.");
                return null;
            }

            xDoc.Load(path);

            var el = xDoc.DocumentElement;
            foreach(XmlNode node in el)
            {
                resultList.AddRange(GetAttribute(node));
            }
            return resultList;
        }

        private static List<string> GetAttribute(XmlNode node)
        {
            List<string> result = new List<string>();
            if(node.Attributes.Count > 0)
            {
                foreach(XmlAttribute attr in node.Attributes)
                {
                    result.Add(attr.Value.ToLower());
                }
            }
            foreach(XmlNode childNode in node.ChildNodes)
            {
               result.AddRange(GetAttribute(childNode));
            }
            return result;
        }
    }
}
