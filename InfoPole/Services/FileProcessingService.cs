using InfoPole.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.DataBase;
using InfoPole.Core.Entities;
using InfoPole.Core.FileParsers;
using InfoPole.Core.Services;
using InfoPole.Core.Utilities;

namespace InfoPole.Services
{
    public class FileProcessingService
    {
        readonly Encoding win1251 = Encoding.GetEncoding("windows-1251");

        private IEnumerable<SearchKey> _searchKeys;
        private IEnumerable<SearchKeyFrequency> _searchKeyFrequencies;
        private IEnumerable<UrlItem> _urls;
        private IEnumerable<UrlKey> _urlKeys;
        private IItemsSaver _itemSaver;

        public FileProcessingService(
        IServerCacheService serverCache,                                                                            
        IItemsSaver itemSaver
    )
        {
            _searchKeys = serverCache.GetList<SearchKey>(); //searchKeys;
            _searchKeyFrequencies = serverCache.GetList<SearchKeyFrequency>();  //searchKeyFrequencies;
            _urls = serverCache.GetList<UrlItem>(); // urls;
            _urlKeys = serverCache.GetList<UrlKey>(); //urlKeys;
            _itemSaver = itemSaver;
        }

        public bool ProcessMarkupTagsFile(string path)
        {
            using (var reader = new StreamReader(path, win1251))
            {
                var headers = reader.ReadLine();
                var parser = DetectReportParserByHeaders(headers);
                if (parser == null) throw new Exception("No parser for given file format");

                while (!reader.EndOfStream)
                {
                    var errors = new List<string>();
                    var line = reader.ReadLine();

                    try
                    {
                    }
                    catch (Exception exp)
                    {

                    }
                }

                return true;
            }
        }

        public bool ProcessFile(string path, int searcherId = 0)
        {

            using (var reader = new StreamReader(path, win1251))
            {
                var headers = reader.ReadLine();
                var parser = DetectReportParserByHeaders(headers);

                if (parser == null) throw new Exception("No parser for given file format");

                while (!reader.EndOfStream)
                {
                    var errors = new List<string>();
                    var line = reader.ReadLine();

                    try
                    {
                        var parsedLine = parser.ParseString(line, searcherId);
                        parsedLine.Key = WordCleaner.ClearFromPunctuatuion(parsedLine.Key);

                        // Get The key
                        var key = _searchKeys.FirstOrDefault(k => k.Key.Equals(parsedLine.Key));
                        if (key == null)
                        {
                            key = new SearchKey()
                            {
                                Key = parsedLine.Key,
                            };
                            _itemSaver.SaveKey(key);
                        }

                        // The key frequency for searchers 
                        var keyFrequency = _searchKeyFrequencies.FirstOrDefault(f => f.SearchKeyId == key.Id && f.SearchEngineId == searcherId);
                        if (keyFrequency == null)
                        {
                            keyFrequency = new SearchKeyFrequency()
                            {
                                SearchEngineId = searcherId,
                                Frequency = parsedLine.ShowingsNumber,
                                TimeStamp = DateTime.UtcNow
                            };
                            _itemSaver.SaveSearchKeyFrequency(keyFrequency);
                        }

                        // Url for the key
                        var url = _urls.FirstOrDefault(u => u.Url.Equals(parsedLine.Url));
                        if (url == null)
                        {
                            url = new UrlItem()
                            {
                                Url = parsedLine.Url,
                                Domain = new Uri(parsedLine.Url).IdnHost
                            };
                            _itemSaver.SaveUrl(url);
                        }

                        // Match url for the key
                        var urlKey = _urlKeys.FirstOrDefault(uk => uk.KeyId == key.Id && uk.UrlId == url.Id);
                        if (urlKey == null)
                        {
                            urlKey = new UrlKey()
                            {
                                KeyId = key.Id,
                                UrlId = url.Id
                            };
                            _itemSaver.SaveUrlKey(urlKey);
                        }

                        // Add tags for the key



                    }
                    catch (Exception exp)
                    {
                        errors.Add(exp.Message);
                    }

                }
            }

            return true;
        }

        public IFileParser DetectReportParserByHeaders(string headersLine)
        {
            var parsersArray = new List<IFileParser>()
            {
                new KeysSoFileParser(),
                new SpyWordsFileParser()
            };

            var parser = parsersArray.FirstOrDefault(p => p.IsCompatibleFormat(headersLine));
            return parser;
        }
    }
}
