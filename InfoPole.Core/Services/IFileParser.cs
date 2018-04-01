using InfoPole.Core.Entities;

namespace InfoPole.Core.Services
{
    public  interface IFileParser
    {
        bool IsCompatibleFormat(string headers);
        ParseItem ParseString(string line, long searcherId);
  }
}
