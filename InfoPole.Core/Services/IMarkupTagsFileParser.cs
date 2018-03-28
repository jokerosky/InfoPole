using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core.Services
{
    public interface IMarkupTagsFileParser
    {
        IEnumerable<MarkupTag> GetMarkupTagsFromHeader(string headers);
        
    }
}
