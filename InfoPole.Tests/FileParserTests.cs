using InfoPole.Core.FileParsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Services;

namespace InfoPole.Tests
{
    [TestFixture]
    class FileParserTests
    {
        [Test]
        public void Should_detect_parser_by_header()
        {
            var headerSpyWords = TestData.FileHeaders.GetSpyWordsHeader();
            var headerKeysSo = TestData.FileHeaders.GetKeysSoOrganicHeader();

            var keysSoParser = new KeysSoFileParser();
            var spyWordsParser = new SpyWordsFileParser();
            
            Assert.IsTrue(keysSoParser.IsCompatibleFormat(headerKeysSo));
            Assert.IsFalse(keysSoParser.IsCompatibleFormat(headerSpyWords));

            Assert.IsTrue(spyWordsParser.IsCompatibleFormat(headerSpyWords));
            Assert.IsFalse(spyWordsParser.IsCompatibleFormat(headerKeysSo));
        }

        [Test]
        public void KeysSoParser_should_parse_data_line()
        {
            var keysSoParser = new KeysSoFileParser();
            var line = TestData.FileDataLines.GetKeysSoDataLine();
            var keyItem = keysSoParser.ParseString(line, 0);

            Assert.IsFalse(string.IsNullOrWhiteSpace(keyItem.Key));
        }

        [Test]
        public void SpyWordsParser_should_parse_data_line()
        {
            var spyWordsParser = new SpyWordsFileParser();

            var lines = TestData.FileDataLines.GetSpyWordsDataLines();
            foreach (var line in lines)
            {
                var keyItem = spyWordsParser.ParseString(line, 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(keyItem.Key));
            }
        }
    }
}
