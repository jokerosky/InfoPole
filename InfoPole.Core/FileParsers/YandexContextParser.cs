using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Services;

namespace InfoPole.Core.FileParsers
{
    public class YandexContextParser : IFileParser
    {
        public bool IsCompatibleFormat(string headers)
        {
            throw new NotImplementedException();
        }

        public ParseItem ParseString(string line, int searcherId)
        {
            throw new NotImplementedException();
        }
    }
}
