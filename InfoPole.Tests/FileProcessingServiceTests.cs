using System;
using InfoPole.Services;
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

            var fpSvc = new FileProcessingService();

            fpSvc.ProcessFile(path);
        }
    }
}
