using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Models;
using InfoPole.Core.Services;

namespace InfoPole.Tests.Mocks
{
    class MockServerCacheService : IServerCacheService
    {
        private static Dictionary<Type, IEnumerable<object>> _listsCache;

        public int GetListsCount()
        {
            return _listsCache.Count;
        }

        public MockServerCacheService()
        {
            if (_listsCache == null) _listsCache = new Dictionary<Type, IEnumerable<object>>();
        }

        public IList<T> GetList<T>() where T : class
        {
            if (_listsCache.ContainsKey(typeof(T)))
            {
                return _listsCache[typeof(T)] as IList<T>;
            }
            else
            {
                var list = new List<T>();
                _listsCache[typeof(T)] = list;
                return list;
            }
        }

        public OperationResult ReloadLists()
        {
            return new OperationResult(){IsSuccess = true, Number = _listsCache.Count};
        }
    }
}
