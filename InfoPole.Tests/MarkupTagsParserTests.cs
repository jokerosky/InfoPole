using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Services;
using InfoPole.Tests.Mocks;
using NUnit.Framework;

namespace InfoPole.Tests
{
    [TestFixture]
    class MarkupTagsParserTests
    {
        [Test]
        public void Should_return_MarkupTags_and_get_tags_from_raw_line()
        {
            var parser = new MarkupTagsFileParser();
            var mTList = new List<MarkupTag>(30);
            var tList = new List<Tag>(60);
            var saver = new MockItemSaver();

            var mTags = parser.GetAndSaveMarkupTagsFromHeader(
                TestData.FileHeaders.GetMarkupTagsHeader(),
                mTList,
                saver
             ).ToList();

            Assert.IsTrue(mTags.Any());
            Assert.IsTrue(mTList.Count == mTags.Count());

            var cycle = 0;
            foreach (var line in TestData.FileDataLines.GetMarkupTagsDataLines())
            {
                cycle++;                                                    
                var tags = parser.GetAndSaveTagsFromLine(
                    line,
                    mTags,
                    tList,
                    saver).ToList();

                Assert.IsTrue(tags.Any());
                Assert.IsTrue(tList.Count / cycle == tags.Count());
            }


            // repeat should not be doubles
            var countBeforeRepeat = tList.Count;
            foreach (var line in TestData.FileDataLines.GetMarkupTagsDataLines())
            {
                cycle++;
                var tags = parser.GetAndSaveTagsFromLine(
                    line,
                    mTags,
                    tList,
                    saver);
            }
            Assert.IsTrue(tList.Count == countBeforeRepeat);
        }
    }
}
