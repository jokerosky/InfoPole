using InfoPole.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Services
{
  public class FileProcessingService
  {
    public bool ProcessFile(string path)
    {
      Encoding win1251 = Encoding.GetEncoding("windows-1251");
      using (var reader = new StreamReader(path, win1251))
      {
        List<string> listA = new List<string>();

        var headers = reader.ReadLine();


        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          var values = line.Split(';');
          try
          {
            var keyItem = new KeyItem()
            {
              Key = values[0],
              Position = int.Parse(values[3]),
              
            };
          }
          catch (Exception exp)
          {
            
          }

          listA.Add(values[0]);
        }
      }

      return true;
    }

    public void DetectReportFormat(string headersLine)
    {
      var headers = headersLine.Split(new char[] {';'} , StringSplitOptions.RemoveEmptyEntries);

      
    }
  }
}
