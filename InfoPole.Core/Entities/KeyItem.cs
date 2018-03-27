using System;

namespace InfoPole.Core
{
    public class KeyItem
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public int ShowingsNumber { get; set; }
        public int Position { get; set; }
        public int SearchEngineId { get; set; }
    }
}
