using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core.Services
{
    public interface IServerCacheService
    {
         IEnumerable<T> GetList<T>() where T : class;
    }
}
