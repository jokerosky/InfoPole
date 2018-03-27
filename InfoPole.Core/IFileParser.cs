using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core
{
    public  interface IFileParser
    {
        bool IsCompatibleFormat(string headers);
        KeyItem ParseString(string line);
  }
}
