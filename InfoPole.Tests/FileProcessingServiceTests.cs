using System;
using System.Collections.Generic;
using System.Linq;
using InfoPole.Core;
using InfoPole.Core.Entities;
using InfoPole.Services;
using InfoPole.Tests.Mocks;
using NUnit.Framework;

namespace InfoPole.Tests
{
    [TestFixture]
    public class FileProcessingServiceTests
    {
        [Test]
        public void Should_process_csv_file()
        {
            var path = @"C:\dev\test\rivegauche.ru_G_spyw.csv";
            //var path = @"C:\dev\test\rivegauche.ru.organic_Y.keys.csv";

            var fpSvc = new FileProcessingService(
                new MockServerCacheService(),
                new MockItemSaver(),
                new MarkupTagsFileParser()
                );

            fpSvc.ProcessFile(path);
        }

        [Test]
        public void Should_parse_Markup_tags_file()
        {
            var saver = new MockItemSaver();
            var cache = new MockServerCacheService();
            var markupTagsParser = new MarkupTagsFileParser();

            var path = TestData.TessFilesPaths.GetMarkupTagsPath();
            var fpSvc = new FileProcessingService(
                cache,
                saver,
                markupTagsParser
            );

            var result = fpSvc.ProcessMarkupTagsFile(path);
            
            Assert.IsTrue(!result.Messages.Any());
            Assert.IsTrue(cache.GetListsCount() > 1);
            Assert.IsTrue(saver.GetListsCount() > 1);
        }

    }
}
