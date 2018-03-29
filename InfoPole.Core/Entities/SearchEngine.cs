using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
    public class SearchEngine : IIdentifiable
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
