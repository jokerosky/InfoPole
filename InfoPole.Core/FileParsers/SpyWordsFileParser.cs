using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core.FileParsers
{
    public class SpyWordsFileParser : IFileParser
    {
        public bool IsCompatibleFormat(string headers)
        {
            var columns = headers.Split(';');

            var captions = new string[] {
                "\"Запрос\"",
                "\"Доля трафика %\"",
                "\"Показов в месяц\"",
                "\"Позиция\"",
                "\"Изменение позиции\"",
                "\"Сниппет и URL\"",
                "\"Реальный URL\"",
                "" // because of last ;
            };
            var result = true;
            foreach (var column in columns)
            {
                result &= captions.Contains(column.Trim());
            }

            return result;
        }

        public KeyItem ParseString(string line)
        {
            throw new NotImplementedException();
        }
    }
}
