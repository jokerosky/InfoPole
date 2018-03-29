using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
    public class Tag : IIdentifiable
    {
        public long Id { get; set; }
        public string Word { get; set; }

        public long MarkupTagId { get; set; }
    }
}
