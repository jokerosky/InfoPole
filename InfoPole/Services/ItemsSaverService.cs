using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.Entities;
using InfoPole.Core.Entities.DataBase;
using InfoPole.Core.Entities.Interfaces;
using InfoPole.Core.Services;
using InfoPole.Data;

namespace InfoPole.Services
{
    public class ItemsSaverService : IItemsSaver
    {
        private InfoPoleDbContext _ctx;
        public ItemsSaverService(InfoPoleDbContext ctx)
        {
            _ctx = ctx;
        }

        public int SaveChanges()
        {
            return this._ctx.SaveChanges();
        }

        public T SaveItem<T>(T item) where T : class, IIdentifiable
        {
            var table = _ctx.Set<T>();
            if (table == null)
            {
                var type = typeof(T).ToString();
                throw new Exception($"No table for calss [{type}] in database");
            }

            var proxy = table.Add(item);
            return proxy.Entity;
        }

        public SearchKey SaveKey(SearchKey key)
        {
            var item = _ctx.SearchKeys.Add(key);
            this.SaveChanges();
            return item.Entity;

        }

        public UrlItem SaveUrl(UrlItem url)
        {
            var item = _ctx.UrlItems.Add(url);
            this.SaveChanges();
            return item.Entity;
        }

        public UrlKey SaveUrlKey(UrlKey urlKey)
        {
            var item = _ctx.UrlKeys.Add(urlKey);
            this.SaveChanges();
            return item.Entity;
        }

        public SearchKeyFrequency SaveSearchKeyFrequency(SearchKeyFrequency keyFrequency)
        {
            var item = _ctx.SearchKeyFrequencies.Add(keyFrequency);
            this.SaveChanges();
            return item.Entity;
        }
    }
}
