using FShredder.Bll.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Models
{
    public class XmlInfoResult : IParseResult
    {
        public List<DirectoryObject> Directories { get; }

        public XmlInfoResult()
        {
            
        }
        public XmlInfoResult(List<DirectoryObject> directories) => Directories = directories;
    }
}
