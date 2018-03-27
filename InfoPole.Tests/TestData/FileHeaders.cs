using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Tests.TestData
{
    class FileHeaders
    {
        public static IEnumerable<string> GetFileHeaders()
        {
            return new[]
            {
                "page id; Запрос; Страница; Позиция; Базовая частотность; Очень точная частотность; Документов найдено",
                "\"Запрос\";\"Доля трафика %\";\"Показов в месяц\";\"Позиция\";\"Изменение позиции\";\"Сниппет и URL\";\"Реальный URL\";"
            };
        }

        public static string GetKeysSoOrganicHeader()
        {
            return
                "page id; Запрос; Страница; Позиция; Базовая частотность; Очень точная частотность; Документов найдено";
        }

        public static string GetSpyWordsHeader()
        {
            return
                "\"Запрос\";\"Доля трафика %\";\"Показов в месяц\";\"Позиция\";\"Изменение позиции\";\"Сниппет и URL\";\"Реальный URL\";";
        }
    }
}
