using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoPole.Controllers
{
    [Produces("application/json")]
    public class MainController : Controller
    {
        private IServerCacheService _cache;

        public MainController(IServerCacheService cache)
        {
            this._cache = cache;
        }

        public IActionResult Get()
        {
            return Ok("Hello InfoPole visitor");
        }

        [HttpPost("refresh")]
        public IActionResult Post()
        {
            var result = _cache.ReloadLists();
            if(result.IsSuccess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }
    }
}
