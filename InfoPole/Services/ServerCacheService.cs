using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core.Services;
using InfoPole.Data;

namespace InfoPole.Services
{
    public class ServerCacheService : IServerCacheService
    {
        private InfoPoleDbContext _ctx;
        private static Dictionary<Type, IEnumerable<object>> _listsCache;

        public ServerCacheService(InfoPoleDbContext ctx)
        {
            _ctx = ctx;
            if(_listsCache == null) _listsCache = new Dictionary<Type, IEnumerable<object>>();
        }

        public IEnumerable<T> GetList<T>() where T :  class
        {
            if (_listsCache.ContainsKey(typeof(T)))
            {
                return _listsCache[typeof(T)] as IEnumerable<T>;
            }
            else
            {
                var list = _ctx.Set<T>().ToList();
                _listsCache[typeof(T)] = list;
                return list;
            }
        }

        //public int ReLoadLists()
        //{
        //    var types =_ctx.Model.GetEntityTypes();
        //    var sets = _ctx.GetType().GetProperties()
        //        .Where(p => p.PropertyType.Name.Contains("DbSet"))
        //        .Select(p=>p.GetValue(_ctx))
        //        .ToList();

        //    var list = (sets[0] as IEnumerable<object>).ToList();

        //    foreach (var set in sets)
        //    {
        //        //_listsCache.Add( ,set);
        //    }

        //    return types.Count();
        //}
    }
}
