using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Services;

namespace InfoPole.Tests.Mocks
{
    class MockServerCacheService : IServerCacheService
    {
        private static Dictionary<Type, IEnumerable<object>> _listsCache;

        public MockServerCacheService()
        {
            if (_listsCache == null) _listsCache = new Dictionary<Type, IEnumerable<object>>();
        }

        public IEnumerable<T> GetList<T>() where T : class
        {
            if (_listsCache.ContainsKey(typeof(T)))
            {
                return _listsCache[typeof(T)] as IEnumerable<T>;
            }
            else
            {
                var list = new List<T>();
                _listsCache[typeof(T)] = list;
                return list;
            }
        }
    }
}
