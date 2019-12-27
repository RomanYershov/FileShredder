using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using FShredder.Bll.Models;

namespace FShredder.Bll.Utils
{
    public class XmlParser
    {
        public static InfoResult Parse(string path)
        {
            List<string> resultList = new List<string>();
            XmlDocument xDoc = new XmlDocument();
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Logger.Error($"Файл \"{fileInfo.Name}\" не существует в данном расположении.");
                return null;
            }

            try
            {
                xDoc.Load(path);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }

            var el = xDoc.DocumentElement;
            foreach(XmlNode node in el)
            {
                resultList.AddRange(GetAttribute(node));
            }
            var infoResult = new InfoResult(resultList);

            return infoResult;
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
