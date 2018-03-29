using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities.DataBase
{
    public class UrlKey : IIdentifiable
    {
        public long Id { get; set; }
        public long UrlId { get; set; }
        public long KeyId { get; set; }
    }
}
