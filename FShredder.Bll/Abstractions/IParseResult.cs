﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Abstractions
{
    public interface IParseResult
    {
        string Info { get; }
        List<string> InfoList { get; }
    }
}