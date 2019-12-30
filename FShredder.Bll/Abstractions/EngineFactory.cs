using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Abstractions
{
    public abstract class EngineFactory
    {
        public abstract ISearching CreateSearch();
        public abstract IFileService CreateRemove();
        public abstract IParse CreateParser();

    }
}
