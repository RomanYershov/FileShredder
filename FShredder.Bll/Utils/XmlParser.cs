using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using FShredder.Bll.Abstractions;
using FShredder.Bll.Models;

namespace FShredder.Bll.Utils
{
    public class XmlParser : IParse
    {
        private DirectoryObject directory;
        private List<DirectoryObject> directories = new List<DirectoryObject>();
        public IParseResult Parse(string path)
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

            XmlElement el = xDoc.DocumentElement;
            foreach (XmlNode node in el)
            {
                GetAttribute(node);
            }
            var infoResult = new XmlInfoResult(directories);

            return infoResult;
        }

        private IEnumerable<DirectoryObject> GetAttribute(XmlNode node)
        {
            List<string> result = new List<string>();
            if (node.Attributes?.Count > 0)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if (node.Name == "directory")
                    {
                        directory = new DirectoryObject(attr.Value);
                        directories.Add(directory);
                    }
                    result.Add(attr.Value.ToLower());
                }
            }
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Attributes?.Count > 0)
                {
                    FileObject file = new FileObject();
                    foreach (XmlAttribute attr in childNode.Attributes)
                    {

                        switch (attr.Name)
                        {
                            case "name": file.Name = attr.Value; break;
                            case "ignore":
                                bool.TryParse(attr.Value, out var ignor);
                                file.Attributes.IsIgnore = ignor; break;
                            case "mask": file.Attributes.Mask = attr.Value; break;
                            case "datefrom": file.Attributes.DateFrom = !string.IsNullOrEmpty(attr.Value) ? Convert.ToDateTime(attr.Value) : default(DateTime); break;
                        }
                    }
                    directory.Files.Add(file);
                }

                if (childNode.Name != "file")
                    GetAttribute(childNode);
            }
            return directories;
        }
    }
}
