using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Models;

namespace InfoPole.Core.Services
{
    public interface IServerCacheService
    {
        IList<T> GetList<T>() where T : class;
        OperationResult ReloadLists();
    }
}
