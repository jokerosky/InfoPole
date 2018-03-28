using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.DataBase;
using InfoPole.Core.Entities;

namespace InfoPole.Core.Services
{
    public interface IItemsSaver
    {
        T SaveItem<T>(T item) where T : class;

        SearchKey SaveKey(SearchKey key);
        UrlItem SaveUrl(UrlItem url);
        UrlKey SaveUrlKey(UrlKey urlKey);
        SearchKeyFrequency SaveSearchKeyFrequency(SearchKeyFrequency keyFrequency);
    }
}
