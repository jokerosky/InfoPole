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

        public ParseItem ParseString(string line, long searcherId)
        {
            var values = line.Split(new[] { "\";" }, StringSplitOptions.None);

            if (values.Length > 8)
            {
                values[6] = values[7];
            }

            

            int.TryParse(values[3].Replace(" ", "").Replace("\"", ""), out var position);
            int.TryParse(values[2].Replace(" ", "").Replace("\"", ""), out var  showings);

            var keyItem = new ParseItem()
            {
                Key = values[0].Replace("\"", ""),
                Url = values[6].Replace("\"", ""),
                Position = position,
                ShowingsNumber = showings,
                SearchEngineId = searcherId
            };

            return keyItem;
        }
    }
}
