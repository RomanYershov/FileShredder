using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Abstractions
{
    public interface IParse 
    {
        IParseResult Parse(string path);
    }
}
