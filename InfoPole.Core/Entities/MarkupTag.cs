using System.Collections.Generic;
using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Entities
{
    public class MarkupTag : IIdentifiable
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //public IEnumerable<Tag> Tags { get; set; }

    }
}
