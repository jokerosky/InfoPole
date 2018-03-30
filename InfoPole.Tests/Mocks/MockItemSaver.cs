using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.Entities;
using InfoPole.Core.Entities.DataBase;
using InfoPole.Core.Entities.Interfaces;
using InfoPole.Core.Services;

namespace InfoPole.Tests.Mocks
{
    class MockItemSaver : IItemsSaver
    {
        private Dictionary<Type, List<object>> _cache = new Dictionary<Type, List<object>>(10);

        public int GetListsCount()
        {
            return _cache.Count;
        }

        public int SaveChanges()
        {
            return 0;
        }

        public T SaveItem<T>(T item) where T : class, IIdentifiable
        {
            if (!_cache.ContainsKey(typeof(T)))
            {
                _cache[typeof(T)]= new List<object>(100);
            }

            var id = _cache[typeof(T)].Count() + 1;
            item.Id = id;
            _cache[typeof(T)].Add(item);
            return item;
        }

        public SearchKey SaveKey(SearchKey key)
        {
            return SaveItem<SearchKey>(key);
        }

        public UrlItem SaveUrl(UrlItem url)
        {
            return SaveItem<UrlItem>(url);
        }

        public UrlKey SaveUrlKey(UrlKey urlKey)
        {
            return SaveItem<UrlKey>(urlKey);
        }

        public SearchKeyFrequency SaveSearchKeyFrequency(SearchKeyFrequency keyFrequency)
        {
            return SaveItem<SearchKeyFrequency>(keyFrequency);
        }
    }
}
