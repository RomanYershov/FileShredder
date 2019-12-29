using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Abstractions
{
    public interface IService
    {   
        System.Collections.IEnumerable SearchFile(string [] drives ,string searchValue);
        void RemoveFiles(string dirPath, List<string> ignoreFiles);
    }
}
