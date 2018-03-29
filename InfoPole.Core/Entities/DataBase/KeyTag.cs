using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities.DataBase
{
    public class KeyTag : IIdentifiable
    {
        public long Id { get; set; }
        public long KeyId { get; set; }
        public long MarkupTagId { get; set; }
    }
}
