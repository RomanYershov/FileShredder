using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Abstractions
{
    public interface IService
    {   
        System.Collections.IEnumerable ShowAllFiles(string [] drives ,string [] files);
        void RemoveFiles(string dirPath, List<string> files);
    }
}
