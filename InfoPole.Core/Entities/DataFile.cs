using System;
using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
    public class DataFile: IIdentifiable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Uploaded { get; set; }
        public long SearchEngineId { get; set; }
    }
}
