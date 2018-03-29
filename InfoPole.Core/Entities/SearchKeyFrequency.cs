using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
  public class SearchKeyFrequency : IIdentifiable
    {
      public long Id { get; set; }
      public long SearchKeyId { get; set; }
      public long SearchEngineId { get; set; }
      public int Frequency { get; set; }
      public DateTime TimeStamp { get; set; }
  }
}
