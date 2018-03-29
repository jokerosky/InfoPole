using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
    public class UrlItem : IIdentifiable
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Domain { get; set; }
    }
}
