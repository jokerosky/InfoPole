using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Core.Services;

namespace InfoPole.Core.FileParsers
{
    public class SpyWordsFileParser : IFileParser
    {
        public bool IsCompatibleFormat(string headers)
        {
            var columns = headers.Split(';');

            var captions = new string[] {
                "\"Запрос\"", //0
                "\"Доля трафика %\"", //1
                "\"Показов в месяц\"", //2
                "\"Позиция\"", //3
                "\"Изменение позиции\"", //4
                "\"Сниппет и URL\"", //5
                "\"Реальный URL\"", //6
                "" // because of last ;
            };
            var result = true;
            foreach (var column in columns)
            {
                result &= captions.Contains(column.Trim());
            }

            return result;
        }

        public ParseItem ParseString(string line, int searcherId)
        {
            var values = line.Split(';');

            var keyItem = new ParseItem()
            {
                Key = values[1],
                Url = values[2],
                Position = int.Parse(values[3].Replace(" ", "")),
                ShowingsNumber = int.Parse(values[5].Replace(" ", "")),
                SearchEngineId = searcherId
            };

            return keyItem;
        }
    }
}
