using InfoPole.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Core.Entities.DataBase;
using InfoPole.Core.FileParsers;
using InfoPole.Core.Models;
using InfoPole.Core.Services;
using InfoPole.Core.Utilities;

namespace InfoPole.Services
{
    public class FileProcessingService
    {
        readonly Encoding win1251 = Encoding.GetEncoding("windows-1251");

        private IList<SearchKey> _searchKeys;
        private IList<SearchKeyFrequency> _searchKeyFrequencies;
        private IList<UrlItem> _urls;
        private IList<UrlKey> _urlKeys;
        private IList<MarkupTag> _markupTags;
        private IList<Tag> _tags;
        private IList<KeyTag> _keyTags;

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
            _markupTags = serverCache.GetList<MarkupTag>();
            _tags = serverCache.GetList<Tag>();
            _keyTags = serverCache.GetList<KeyTag>();

            _itemSaver = itemSaver;
            
        }

        public OperationResult ProcessMarkupTagsFile(string path, IMarkupTagsFileParser markupTagsParser)
        {
            var count = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var reader = new StreamReader(path, win1251))
            {
                var errors = new List<string>();

                var headers = reader.ReadLine();
                var parsedMarkupTags = markupTagsParser.GetAndSaveMarkupTagsFromHeader(headers, _markupTags, _itemSaver).ToArray();
                _itemSaver.SaveChanges();
                var content = new List<string>(1000);

                while (!reader.EndOfStream) 
                {
                    content.Add(reader.ReadLine());
                    count++;
                }
                reader.Close();

                foreach (string line in content)
                {
                    try
                    {
                        var tags = markupTagsParser.GetAndSaveTagsFromLine(line, parsedMarkupTags, _tags, _itemSaver);
                    }
                    catch (Exception exp)
                    {
                        errors.Add(exp.Message);
                    }
                }
                _itemSaver.SaveChanges();
                stopwatch.Stop();
                return new OperationResult()
                {
                    Number = count,
                    Messages = errors,
                    IsSuccess = true,
                    ElapsedTime = stopwatch.Elapsed 
                };
            }
        }

        public OperationResult ProcessFile(string path, long searcherId = 0)
        {
            var count = 0;
            var errors = new List<string>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (var reader = new StreamReader(path, win1251))
            {
                var headers = reader.ReadLine();
                var parser = DetectReportParserByHeaders(headers);

                if (parser == null) throw new Exception("No parser for given file format");

                while (!reader.EndOfStream)
                {
                    
                    var line = reader.ReadLine();
                    count++;

                    try
                    {
                        var parsedLine = parser.ParseString(line, searcherId);
                        parsedLine.Key = WordCleaner.ClearFromPunctuatuion(parsedLine.Key);
                        var isNewKey = false;

                        // Get The key
                        var key = _searchKeys.FirstOrDefault(k => k.Key.Equals(parsedLine.Key));
                        if (key == null)
                        {
                            
                            key = new SearchKey()
                            {
                                Key = parsedLine.Key,
                                WordsNumber = parsedLine.Key.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).Length
                            };
                            _itemSaver.SaveKey(key);
                            _searchKeys.Add(key);
                            isNewKey = true;
                        }

                        if (isNewKey)
                        {
                            var tags = _tags.Where(t => key.Key.Contains(t.Word));

                            foreach (var tag in tags)
                            {
                                var keyTag = new KeyTag()
                                {
                                    KeyId = key.Id,
                                    MarkupTagId = tag.MarkupTagId
                                };
                                _itemSaver.SaveItem<KeyTag>(keyTag);
                                _keyTags.Add(keyTag);
                            }
                            _itemSaver.SaveChanges();
                        }
                        

                        // The key frequency for searchers 
                        var keyFrequency = _searchKeyFrequencies.FirstOrDefault(f => f.SearchKeyId == key.Id && f.SearchEngineId == searcherId);
                        if (keyFrequency == null)
                        {
                            keyFrequency = new SearchKeyFrequency()
                            {
                                SearchKeyId = key.Id,
                                SearchEngineId = searcherId,
                                Frequency = parsedLine.ShowingsNumber,
                                TimeStamp = DateTime.UtcNow
                            };
                            _itemSaver.SaveSearchKeyFrequency(keyFrequency);
                            _searchKeyFrequencies.Add(keyFrequency);
                        }

                        // Url for the key
                        if (!Uri.IsWellFormedUriString(parsedLine.Url, UriKind.Absolute))
                        {
                            continue;
                        }
                        var url = _urls.FirstOrDefault(u => u.Url.Equals(parsedLine.Url));
                        if (url == null)
                        {
                            url = new UrlItem()
                            {
                                Url = parsedLine.Url,
                                Domain = new Uri(parsedLine.Url).IdnHost
                            };
                            _itemSaver.SaveUrl(url);
                            _urls.Add(url);
                        }

                        // Match url for the key
                        var urlKey = _urlKeys.FirstOrDefault(uk => uk.KeyId == key.Id && uk.UrlId == url.Id);
                        if (urlKey == null)
                        {
                            urlKey = new UrlKey()
                            {
                                KeyId = key.Id,
                                UrlId = url.Id,

                                Position = parsedLine.Position,
                                SearcherId = searcherId,
                                TimeStamp = DateTime.UtcNow
                            };
                            _itemSaver.SaveUrlKey(urlKey);
                            _urlKeys.Add(urlKey);
                        }
                    }
                    catch (Exception exp)
                    {
                        errors.Add(exp.Message);
                    }
                }
            }

            _itemSaver.SaveChanges();
            stopwatch.Stop();
            return new OperationResult()
            {
                Number = count,
                Messages = errors,
                IsSuccess = true,
                ElapsedTime = stopwatch.Elapsed
            };
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
