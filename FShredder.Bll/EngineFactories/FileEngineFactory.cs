using System;
using System.Collections.Generic;
using System.Text;
using FShredder.Bll.Abstractions;
using FShredder.Bll.Models;
using FShredder.Bll.Utils;

namespace FShredder.Bll.EngineFactories
{
    public class FileEngineFactory : EngineFactory
    {
        public override ISearching CreateSearch()
        {
            return  new TextSearch();
        }

        public override IFileService CreateRemove()
        {
            return  new FileEngine();
        }

        public override IParse CreateParser()
        {
           return  new XmlParser();
        }
    }
}
