using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities;

namespace InfoPole.Core.Services
{
    public interface IMarkupTagsFileParser
    {
        IEnumerable<MarkupTag> GetAndSaveMarkupTagsFromHeader(
            string headers,
            IList<MarkupTag> markupTags,
            IItemsSaver saver);

        IEnumerable<Tag> GetAndSaveTagsFromLine(
            string line,
            IEnumerable<MarkupTag> markupTags,
            IList<Tag> tags,
            IItemsSaver saver);
    }
}
