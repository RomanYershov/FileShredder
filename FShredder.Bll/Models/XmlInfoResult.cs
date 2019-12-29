using FShredder.Bll.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Models
{
    public class XmlInfoResult : IParseResult
    {
        public XmlInfoResult(List<string> parseResult)  
        {
            DirectoryName = parseResult[0];
            parseResult.RemoveAt(0);
            IgnoreFiles = parseResult;
        }
        public string DirectoryName { get; }
        public List<string> IgnoreFiles { get; }
    }
}
