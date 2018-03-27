using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.DataBase;
using InfoPole.Core.Entities;
using InfoPole.Core.Services;

namespace InfoPole.Tests.Mocks
{
    class MockItemSaver : IItemsSaver
    {
        public SearchKey SaveKey(SearchKey key)
        {
            return key;
        }

        public UrlItem SaveUrl(UrlItem url)
        {
            return url;
        }

        public UrlKey SaveUrlKey(UrlKey urlKey)
        {
            return urlKey;
        }
    }
}
