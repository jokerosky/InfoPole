using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPole.Core.Entities;

namespace InfoPole.Core.Services
{
  public interface ITagsMatcherService
  {
      int AddTagsForKey(SearchKey key);
  }
}
