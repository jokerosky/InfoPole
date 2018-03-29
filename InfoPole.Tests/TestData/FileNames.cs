using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Tests.TestData
{
    class TessFilesPaths
    {
        public static IEnumerable<string> GetPaths()
        {
            return new string[]
            {
                @"C:\dev\test\rivegauche.ru.organic_G.keys.csv",
                @"C:\dev\test\rivegauche.ru.organic_Y.keys.csv",
                @"C:\dev\test\rivegauche.ru_G_spyw.csv",
                @"C:\dev\test\rivegauche.ru_Y_spyw.csv"
            };
        }

        public static string GetMarkupTagsPath()
        {
            return @"C:\dev\test\markupTags.csv";
        }
    }
}
