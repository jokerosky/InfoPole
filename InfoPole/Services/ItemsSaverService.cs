using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.Entities;
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

      public SearchKey SaveKey(SearchKey key)
      {
        var item =  _ctx.SearchKeys.Add(key);
        return item.Entity;
      }

      public UrlItem SaveUrl(UrlItem url)
      {
      var item = _ctx.UrlItems.Add(url);
        return item.Entity;
    }
    }
}
