using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
    public class ParseItem : IIdentifiable
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public int ShowingsNumber { get; set; }
        public int Position { get; set; }
        public long SearchEngineId { get; set; }
    }
}
