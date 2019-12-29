using System;
using System.Collections.Generic;
using System.Text;
using FShredder.Bll.Models;

namespace FShredder.Bll.Abstractions
{
    public interface IParse 
    {
        IParseResult Parse(string path);
    }
}
