﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Abstractions
{
    public interface IFileService   
    {
        void RemoveFiles(string dirPath, List<string> ignoreFiles);
    }
}