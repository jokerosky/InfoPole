using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoPole.Controllers
{
    [Produces("application/json")]
    public class MainController : Controller
    {
      public IActionResult Get()
      {
        return Ok("Hello InfoPole visitor");
      }
    }
}
