using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core.Entities
{
  public class SearchKeyFrequency
  {
      public long Id { get; set; }
      public long SearchKeyId { get; set; }
      public int SearchEngineId { get; set; }
      public int Frequency { get; set; }
      public DateTime TimeStamp { get; set; }
  }
}
