using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoPole.Controllers
{
    [Produces("application/json")]
    [Route("Tag")]
    public class TagsController : Controller
    {
        private IEnumerable<Tag> _tags;
        public TagsController(IServerCacheService cache)
        {
            _tags = cache.GetList<Tag>();
        }

        [HttpGet]
        public IActionResult Tag(long markupTagId)
        {
            var tags = _tags.Where(mt => mt.MarkupTagId == markupTagId).ToList();
            return Ok(tags);
        }
    }
}