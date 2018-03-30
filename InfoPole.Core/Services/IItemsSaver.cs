using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Core.Entities.DataBase;
using InfoPole.Core.Entities.Interfaces;

namespace InfoPole.Core.Services
{
    public interface IItemsSaver
    {

        int SaveChanges();
        T SaveItem<T>(T item) where T : class, IIdentifiable;

        SearchKey SaveKey(SearchKey key);
        UrlItem SaveUrl(UrlItem url);
        UrlKey SaveUrlKey(UrlKey urlKey);
        SearchKeyFrequency SaveSearchKeyFrequency(SearchKeyFrequency keyFrequency);
    }
}
