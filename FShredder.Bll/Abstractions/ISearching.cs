using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Abstractions
{
    public interface ISearching
    {
        IEnumerable Search(string [] directories, string searchValue);
    }
}
