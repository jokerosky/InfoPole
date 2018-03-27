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

namespace InfoPole.Services
{
  public class FileProcessingService
  {
    private IEnumerable<SearchKey> _searchKeys;
    private IEnumerable<UrlItem> _urls;
    private IEnumerable<UrlKey> _urlKeys;
    private IItemsSaver _itemSaver;

    public FileProcessingService(
        IEnumerable<SearchKey> searchKeys,
        IEnumerable<UrlItem> urls,
        IEnumerable<UrlKey> urlKeys,
        IItemsSaver itemSaver
      )
    {
      _searchKeys = searchKeys;
      _urls = urls;
      _urlKeys = urlKeys;
      _itemSaver = itemSaver;
    }

    public bool ProcessFile(string path)
    {
      Encoding win1251 = Encoding.GetEncoding("windows-1251");
      using (var reader = new StreamReader(path, win1251))
      {
        var headers = reader.ReadLine();
        var parser = DetectReportParserByHeaders(headers);

        while (!reader.EndOfStream)
        {
          var errors = new List<string>();
          var line = reader.ReadLine();

          try
          {
            var parsedLine = parser.ParseString(line, 0);

            var key = _searchKeys.FirstOrDefault(k => k.Key.Equals(parsedLine.Key));
            if (key == null)
            {
              key = new SearchKey()
              {
                Key = parsedLine.Key
              };
              _itemSaver.SaveKey(key);
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
            }

            var urlKey = _urlKeys.FirstOrDefault(uk =>  uk.KeyId == key.Id && uk.UrlId == url.Id);
            if (urlKey == null)
            {
              urlKey = new UrlKey()
              {
                KeyId = key.Id,
                UrlId = url.Id
              };
              _itemSaver.SaveUrlKey(urlKey);
            }
            

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
