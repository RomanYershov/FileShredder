﻿using FShredder.Bll.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Models
{
    public class XmlInfoResult : IParseResult
    {
        public XmlInfoResult(List<string> parseResult)  
        {
            Info = parseResult[0];
            parseResult.RemoveAt(0);
            InfoList = parseResult;
        }

        public string Info { get; }
        public List<string> InfoList { get; }
    }
}
