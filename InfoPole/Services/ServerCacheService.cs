using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Core.Entities.DataBase;
using InfoPole.Core.Entities.Interfaces;
using InfoPole.Core.Models;
using InfoPole.Core.Services;
using InfoPole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace InfoPole.Services
{
    public class ServerCacheService : IServerCacheService
    {
        private InfoPoleDbContext _ctx;
        private static Dictionary<Type, IEnumerable<object>> _listsCache;
        //private static Dictionary<string, IEnumerable<object>> _listsCacheByTable;

        public ServerCacheService(InfoPoleDbContext ctx)
        {
            _ctx = ctx;
            if (_listsCache == null) _listsCache = new Dictionary<Type, IEnumerable<object>>();
        }

        public IList<T> GetList<T>(bool isRefresh = false) where T : class
        {
            var tableName = _ctx.Model.FindEntityType(typeof(T)).Relational().TableName;

            if (_listsCache.ContainsKey(typeof(T)) && !isRefresh)
            {
                return _listsCache[typeof(T)] as IList<T>;
            }
            else
            {
                var list = _ctx.Set<T>().ToList();
                _listsCache[typeof(T)] = list;
                return list;
            }
        }

        public IList<T> GetList<T>() where T : class
        {
            return this.GetList<T>(false);
        }

        public OperationResult ReloadLists()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var count = 0;

            this.GetList<SearchKey>(isRefresh: true);
            this.GetList<SearchEngine>(isRefresh: true);
            this.GetList<SearchKeyFrequency>(isRefresh: true);
            this.GetList<MarkupTag>(isRefresh: true);
            this.GetList<Tag>(isRefresh: true);
            this.GetList<UrlItem>(isRefresh: true);
            this.GetList<UrlKey>(isRefresh: true);
            this.GetList<KeyTag>(isRefresh: true);
            this.GetList<DataFile>(isRefresh: true);

            //TODO ↓ add refresh with generics and relections
            //var sets = _ctx.GetType().GetProperties().Where(x => x.PropertyType.ToString().Contains("DbSet"));
            //foreach (var setProperty in sets)
            //{
            //    _listsCacheByTable[setProperty.Name] = setProperty.GetValue(_ctx);
            //}

            stopwatch.Stop();
            return new OperationResult()
            {
                IsSuccess = true,
                ElapsedTime = stopwatch.Elapsed,
                Number = count    
            };
        }
    }
}
