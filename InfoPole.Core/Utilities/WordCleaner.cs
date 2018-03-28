using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core.Utilities
{
  public class WordCleaner
  {
      public static string ClearFromPunctuatuion(string line)
      {
          var punctuation = new[] { ",", ".", ";", "-", ":", "_", ")", "(", "!", "?"};

          foreach (var symbol in punctuation)
          {
              line = line.Replace(symbol, " ");
          }

          line = line.Replace("ё", "е");

          return line;
      }
  }
}
