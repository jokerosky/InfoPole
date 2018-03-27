using System;
using System.Linq;
using System.Threading.Tasks;

namespace InfoPole.Core.FileParsers
{
    public class KeysSoFileParser : IFileParser
    {
        public bool IsCompatibleFormat(string headers)
        {
            var columns = headers.Split(';');

            var captions = new string[] { 
                "page id", //0
                "Запрос", //1
                "Страница", //2
                "Позиция", //3
                "Базовая частотность", //4
                "Очень точная частотность", //5
                "Документов найдено" //6
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
