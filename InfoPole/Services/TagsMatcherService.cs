using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.DataBase;
using InfoPole.Core.Entities;
using InfoPole.Core.Services;

namespace InfoPole.Services
{
	public class TagsMatcherService : ITagsMatcherService
	{
		private IEnumerable<Tag> _tags;
		private IEnumerable<MarkupTag> _markupTags;
		private IEnumerable<KeyTag> _keyTags;

		private IItemsSaver _saver;

		public TagsMatcherService(
				IEnumerable<Tag> tags,
				IEnumerable<MarkupTag> markupTags,
				IEnumerable<KeyTag> keyTags,
				IItemsSaver saver
			)
		{
			_tags = tags;
			_markupTags = markupTags;
			_keyTags = keyTags;

			_saver = saver;
		}

		private Dictionary<MarkupTag, IEnumerable<Tag>> GetDictionary()
		{
			var tagsDictionary = new Dictionary<MarkupTag, IEnumerable<Tag>>();

			foreach (var markupTag in _markupTags)
			{
				tagsDictionary.Add(markupTag, _tags.Where(t=>t.MarkupTagId == markupTag.Id));
			}

			return tagsDictionary;
		}

		public int AddTagsForKey(SearchKey key)
		{
			var newTagsCount = 0;
			var dict = GetDictionary();

			foreach (var item in dict) {
				foreach (var tagKeys in item.Value)
				{
					if (key.Key.Contains(tagKeys.Word))
					{
						if (!_keyTags.Any(kt => kt.KeyId == key.Id && kt.MarkupTagId == item.Key.Id))
						{
							var keyTag = new KeyTag()
							{
								MarkupTagId = item.Key.Id,
								KeyId = key.Id
							};
							_saver.SaveItem<KeyTag>(keyTag);
							newTagsCount++;
						}
					}
				}
			}

			return newTagsCount;
		}
	}
}
