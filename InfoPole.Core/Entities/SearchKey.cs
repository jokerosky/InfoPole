using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
    public class SearchKey : IIdentifiable
    {
        public long Id { get; set; }
        public string Key { get; set; }
    }
}
