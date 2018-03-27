using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core.FileParsers
{
    public class KeysSoFileParser : IFileParser
    {
        public bool IsCompatibleFormat(string headers)
        {
            var columns = headers.Split(';');

            var captions = new string[] { 
                "page id",
                "Запрос",
                "Страница",
                "Позиция",
                "Базовая частотность",
                "Очень точная частотность",
                "Документов найдено"
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
