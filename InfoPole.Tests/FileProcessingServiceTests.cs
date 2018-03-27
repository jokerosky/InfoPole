using System;
using System.Collections.Generic;
using InfoPole.Core;
using InfoPole.Core.DataBase;
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
                new List<SearchKey>(),
                new List<UrlItem>(),
                new List<UrlKey>(), 
                new MockItemSaver()
                );

            fpSvc.ProcessFile(path);
        }
    }
}
