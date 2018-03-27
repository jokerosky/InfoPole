using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoPole.Controllers
{
  [Produces("application/json")]
  [Route("files")]
  public class FilesController : Controller
  {
    [HttpPost]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> Post()
    {
      var files = Request.Form.Files;
      var fnum = files.Count;
      foreach (var file in files)
      {
        var path = Path.GetTempPath() + file.FileName;
        var fileStream = new FileStream(path, FileMode.CreateNew);
        try
        {
          await file.CopyToAsync(fileStream);
          fileStream.Close();
        }
        catch (Exception exp)
        {
          fileStream.Close();
          return StatusCode(500, exp.Message);
        }
      }
      

      return Ok(fnum);
    }
  }
}
