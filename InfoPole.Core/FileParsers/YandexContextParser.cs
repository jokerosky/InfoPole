﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Core.Services;

namespace InfoPole.Core.FileParsers
{
    public class YandexContextParser : IFileParser
    {
        public bool IsCompatibleFormat(string headers)
        {
            throw new NotImplementedException();
        }

        public ParseItem ParseString(string line, long searcherId)
        {
            throw new NotImplementedException();
        }
    }
}
