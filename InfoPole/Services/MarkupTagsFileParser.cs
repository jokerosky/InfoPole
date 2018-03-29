using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.Entities;
using InfoPole.Core.Services;

namespace InfoPole.Services
{
    public class MarkupTagsFileParser : IMarkupTagsFileParser
    {
        public IEnumerable<MarkupTag> GetAndSaveMarkupTagsFromHeader(string headers, IList<MarkupTag> markupTags, IItemsSaver saver)
        {
            var values = headers.Split(';');
            var result = new List<MarkupTag>();

            foreach (var value in values)
            {
                var mTag = markupTags.FirstOrDefault(mt =>
                    mt.Name.Equals(value, StringComparison.InvariantCultureIgnoreCase));
                if (mTag == null)
                {
                    mTag = saver.SaveItem<MarkupTag>(new MarkupTag() { Name = value });
                    markupTags.Add(mTag);
                }
                result.Add(mTag);
            }

            return result;
        }


        public IEnumerable<Tag> GetAndSaveTagsFromLine(string line, IEnumerable<MarkupTag> markupTags, IList<Tag> tags, IItemsSaver saver)
        {
            var values = line.Split(';');
            var result = new List<Tag>();

            if (values.Length != markupTags.Count())
            {
                throw new Exception("Number of values does not equal number of makup tags");
            }

            markupTags = markupTags.ToArray();
            for (var i = 0; i < values.Length; i++)
            {
                if(string.IsNullOrWhiteSpace(values[i].Trim())) continue;

                var markupTagId = ((MarkupTag[]) markupTags)[i].Id;
                var tag = tags.FirstOrDefault(t => t.Word.Equals(values[i], StringComparison.InvariantCultureIgnoreCase)
                && t.MarkupTagId == markupTagId);

                if (tag == null)
                {
                    tag = new Tag()
                    {
                        MarkupTagId = markupTagId,
                        Word = values[i]
                    };
                    tag = saver.SaveItem<Tag>(tag);
                    tags.Add(tag);
                }

                result.Add(tag);
            }

            return result;
        }
    }
}
