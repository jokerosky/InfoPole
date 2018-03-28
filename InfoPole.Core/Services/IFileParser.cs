﻿namespace InfoPole.Core.Services
{
    public  interface IFileParser
    {
        bool IsCompatibleFormat(string headers);
        ParseItem ParseString(string line, int searcherId);
  }
}