using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FShredder.Bll.Abstractions;

namespace FShredder.Bll.Models
{
    public class Engine
    {
        private readonly ISearching _search;
        private readonly IFileService _fService;
        private readonly IParse _xmlParser;

        public Engine(EngineFactory eFactory)
        {
            _search = eFactory.CreateSearch();
            _fService = eFactory.CreateRemove();
            _xmlParser = eFactory.CreateParser();
        }

        public IEnumerable Search(string[] directories, string value)
        {
            return _search.Search(directories, value);
        }

        public void RemoveFiles(IParseResult parseResult)
        {
            _fService.RemoveFiles(parseResult);
        }

        public IParseResult Parse(string xmlFilePath)
        {
            return _xmlParser.Parse(xmlFilePath);
        }
    }
}
