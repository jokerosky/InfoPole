using System;
using System.Collections.Generic;
using System.Text;

namespace InfoPole.Core
{
    public class MarkupTag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

    }
}
