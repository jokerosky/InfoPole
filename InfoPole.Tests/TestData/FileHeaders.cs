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

        public static string GetMarkupTagsHeader()
        {
            return
                "Транзакционные;Нейтральные предлоги;Отрицание;Информационные;Местоимения;Информационные 1;Поиск работы;Города СССР;Города России;Города России > 100 000 население;Города московской области;Города Украины;Города Беларуси;Города Казахстана;Места в Москве;Крупные ресурсы;Бесплатно или даром;Недорого дешево акции;Своими руками уроки;Обсценная лексика;Adult;Женские имена;Мужские имена";
        }

        
    }
}
