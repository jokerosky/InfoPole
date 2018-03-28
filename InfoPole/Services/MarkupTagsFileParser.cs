using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.Services;

namespace InfoPole.Services
{
    public class MarkupTagsFileParser : IMarkupTagsFileParser
    {
        public IEnumerable<MarkupTag> GetMarkupTagsFromHeader(string headers)
        {
            var values = headers.Split(';');
            var result = new List<MarkupTag>();

            foreach (var value in values)
            {
                
            }

            return result;
        }

    }
}
