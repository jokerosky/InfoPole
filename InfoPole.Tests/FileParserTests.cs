using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Tests
{
    [TestFixture]
    class FileParserTests
    {
        [Test]
        public void Should_detect_parser_by_header()
        {
            var headerSpyWords = "\"Запрос\";\"Доля трафика %\";\"Показов в месяц\";\"Позиция\";\"Изменение позиции\";\"Сниппет и URL\";\"Реальный URL\";";
            var headerKeysSo = "page id; Запрос; Страница; Позиция; Базовая частотность; Очень точная частотность; Документов найдено"
        }
        
    }
}
